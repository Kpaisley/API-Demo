using System.ComponentModel.DataAnnotations;

namespace ReservationAPI.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
