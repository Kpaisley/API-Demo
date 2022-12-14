using ReservationAPI.Models.ModelsDTO;

namespace ReservationAPI.Data.Interfaces
{
    public interface IOrderRepo
    {
        IEnumerable<OrderReadDTO> Get();
        OrderReadDTO Get(int id);
        void Delete(int id);
        void Update(int id, OrderCreateDTO item);
        void Create(OrderCreateDTO item);
    }
}
