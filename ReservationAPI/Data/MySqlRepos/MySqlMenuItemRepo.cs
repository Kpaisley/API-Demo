using Microsoft.Extensions.Logging.Abstractions;
using ReservationAPI.Data.Interfaces;
using ReservationAPI.Models;
using ReservationAPI.Models.ModelsDTO;

namespace ReservationAPI.Data.MySqlRepos
{
    public class MySqlMenuItemRepo : IMenuItemRepo
    {
        private readonly AppDbContext _context;
        private readonly Mapper _mapper = new Mapper();

        public MySqlMenuItemRepo(AppDbContext context) 
        {
            _context = context;
        }
        public void Create(MenuItemCreateDTO item)
        {
            MenuItem newMenuItem = _mapper.Map(item);
            _context.Add(newMenuItem);
            _context.SaveChanges();

            
        }

        public void Delete(int id)
        {
            MenuItem menuItemInDB = _context.MenuItems.ToList().Find(m => m.ID == id);
           

            if (menuItemInDB == null)
            {
                throw new Exception($"ID ({id}) was not found.");
            }
            _context.MenuItems.Remove(menuItemInDB);
            _context.SaveChanges();
        }

        public IEnumerable<MenuItemReadDTO> Get()
        {
            return _context.MenuItems.Select(m => _mapper.Map(m)).ToList();
        }

        public MenuItemReadDTO Get(int id)
        {
            MenuItem menuItemInDB = _context.MenuItems.ToList().Find(m => m.ID== id);
            if (menuItemInDB == null)
            {
                return null;
            }
            return _mapper.Map(menuItemInDB);


            
        }

        public void Update(int id, MenuItemCreateDTO item)
        {
            MenuItem menuItemInDB = _context.MenuItems.ToList().Find(m => m.ID == id);
            
            if (menuItemInDB == null)
            {
                throw new Exception($"ID ({id}) was not found.");
            }
            menuItemInDB.Name = item.Name;
            menuItemInDB.Price = item.Price;

            _context.SaveChanges();
            

        }
    }
}
