using ReservationAPI.Data.Interfaces;
using ReservationAPI.Models;
using ReservationAPI.Models.ModelsDTO;

namespace ReservationAPI.Data.MySqlRepos
{
    public class MySqlOrderRepo : IOrderRepo
    {
        private readonly AppDbContext _context;
        private readonly Mapper _mapper = new Mapper();

        public MySqlOrderRepo(AppDbContext context)
        {
            _context = context;
        }
        public void Create(OrderCreateDTO item)
        {
            Order orderToAdd = _mapper.Map(item);
            if (item.MenuItemIDs.Count <= 0)
            {
                throw new Exception($"You must include at least 1 menu item.");
            }

            foreach (var id in item.MenuItemIDs)
            {
                
                var IDcheck = _context.MenuItems.Where(m => m.ID == id).FirstOrDefault();
                if (IDcheck == null)
                {
                    throw new Exception($"No menu item with ID = {id}");
                }
            }
            _context.Orders.Add(orderToAdd);
            _context.SaveChanges();
            foreach (var id in item.MenuItemIDs)
            {               
                var res = new Reservation
                {
                    orderID = orderToAdd.ID,
                    menuItemID = id

                };
                _context.Reservations.Add(res);               
            }
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Order? orderToDelete = _context.Orders.Find(id);

            if (orderToDelete == null)
            {
                throw new Exception($"Could not find Order with ID = {id}");
            }
            
                var menuItemRange = _context.Reservations.Where(o => o.orderID == id).ToList();
                _context.Reservations.RemoveRange(menuItemRange);
                _context.Orders.Remove(orderToDelete);
                _context.SaveChanges();
            
        }

        public IEnumerable<OrderReadDTO> Get()
        {
            //var orders = _context.Orders.Select(o => _mapper.Map(o)).ToList();
            //var menuItems = _context.MenuItems.Select(m => _mapper.Map(m)).ToList();
            //var reservations = _context.Reservations.ToList();

            //foreach (var order in orders)
            //{
            //    List<MenuItemReadDTO> menuItemsToAdd = new List<MenuItemReadDTO>();
            //    foreach (var res in reservations)
            //    {
            //        if (res.orderID == order.ID)
            //        {
            //            var menuItemInDB = menuItems.FirstOrDefault(m => m.ID == res.menuItemID);

            //            if (menuItemInDB != null)
            //            {
            //                menuItemsToAdd.Add(menuItemInDB);
            //            }
            //        }
            //        order.MenuItems = menuItemsToAdd;
            //    }

            //}

            var orders =_context.Orders.Select(o => new OrderReadDTO
            {
                ID= o.ID,
                Name= o.Name,
                Date= o.Date,
                MenuItems = _context.Reservations
                                                .Where(r => r.orderID == o.ID)
                                                .Select(c => new MenuItemReadDTO
                                                {
                                                    ID= c.MenuItem.ID,
                                                    Name = c.MenuItem.Name,
                                                    Price= c.MenuItem.Price,
                                                }).ToList()
            });

            return orders;
        }

        public OrderReadDTO Get(int id)
        {
            var order = _context.Orders.Where(o => o.ID == id).Select(o => new OrderReadDTO
            {
                ID = o.ID,
                Name = o.Name,
                Date = o.Date,
                MenuItems = _context.Reservations
                                                .Where(r => r.orderID == o.ID)
                                                .Select(c => new MenuItemReadDTO
                                                {
                                                    ID = c.MenuItem.ID,
                                                    Name = c.MenuItem.Name,
                                                    Price = c.MenuItem.Price,
                                                }).ToList()
            }).FirstOrDefault();
      
            return order;
        }

        public void Update(int id, OrderCreateDTO item)
        {
            
            var orderInDB = _context.Orders.ToList().Find(o => o.ID == id);
            List<Reservation> resInDB = _context.Reservations.Where(r => r.orderID == id).ToList();

            if(resInDB.Count != item.MenuItemIDs.Count)
            {
                throw new Exception($"You must have the same number of menu items as the order you wish to update. ({resInDB.Count})");
            }

            if (orderInDB == null)
            {
                throw new Exception($"No Order found with ID = {id}");
            }
            

            for (int i = 0; i < resInDB.Count; i++)
            {
                resInDB[i].menuItemID = item.MenuItemIDs[i];
            }
            //var i = 0;
            //foreach (var res in resInDB)
            //{

            //    res.menuItemID = item.MenuItemIDs[i];
            //    i++;
            //    var result = _context.MenuItems.Where(m => m.ID == i).FirstOrDefault();
            //    if(result == null)
            //    {
            //        break;
            //    }
            //}


            orderInDB.Name = item.Name;
            orderInDB.Date = item.Date;
            _context.SaveChanges();
        }
    }
}
