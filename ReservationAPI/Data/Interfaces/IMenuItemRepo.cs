using ReservationAPI.Models;
using ReservationAPI.Models.ModelsDTO;

namespace ReservationAPI.Data.Interfaces
{
    public interface IMenuItemRepo
    {
        IEnumerable<MenuItemReadDTO> Get();
        MenuItemReadDTO Get(int id);
        void Delete(int id);
        void Update(int id, MenuItemCreateDTO item);
        void Create(MenuItemCreateDTO item);
    }
}
