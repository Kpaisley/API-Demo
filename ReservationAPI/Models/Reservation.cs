using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationAPI.Models
{
    public class Reservation
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("MenuItem")]
        public int menuItemID { get; set; }
        public MenuItem MenuItem { get; set; }

        [ForeignKey("Customer")]
        public int orderID { get; set; }
        public Order Order { get; set; }





    }
}
