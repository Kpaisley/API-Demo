using System.ComponentModel.DataAnnotations;

namespace ReservationAPI.Models
{
    public class MenuItem
    {
        [Key]
        public int ID { get; set; } 
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
