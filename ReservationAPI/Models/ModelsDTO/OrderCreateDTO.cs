namespace ReservationAPI.Models.ModelsDTO
{
    public class OrderCreateDTO
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<int> MenuItemIDs { get; set; } 
    }
}
