namespace ReservationAPI.Models.ModelsDTO
{
    public class OrderReadDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<MenuItemReadDTO> MenuItems { get; set; }
    }
}
