using ReservationAPI.Models;
using ReservationAPI.Models.ModelsDTO;

namespace ReservationAPI.Data
{
    public class Mapper
    {
        //MENU ITEM MAPPER
        public MenuItem Map(MenuItemReadDTO input)
        {
            return new MenuItem
            {
                ID = input.ID,
                Name = input.Name,
                Price = input.Price
            };
        }

        public MenuItemReadDTO Map(MenuItem item)
        {
            return new MenuItemReadDTO
            {
                ID = item.ID,
                Name = item.Name,
                Price = item.Price
            };
        }

        public MenuItem Map(MenuItemCreateDTO input)
        {
            return new MenuItem
            {
                
                Name = input.Name,
                Price = input.Price
            };
        }
        //*************************************************
        //ORDER MAPPER
        public OrderReadDTO Map(Order input)
        {
            return new OrderReadDTO
            {
                ID = input.ID,
                Name = input.Name,
                Date = input.Date,
                MenuItems = new List<MenuItemReadDTO>()
            };
        }

        public Order Map(OrderCreateDTO input)
        {
            return new Order
            {
                Name = input.Name,
                Date = input.Date
            };
        }

    }
}
