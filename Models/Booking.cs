using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using TravelLove.Models;

namespace TravelLove.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [ForeignKey("RegisterUser")]
        public int UserId { get; set; }

        [ForeignKey("BusDetails")] // Specify the navigation property name
        public int BusId { get; set; }
        [Required]
        public string BusName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int FirstAC { get; set; }
        public int SecondAC { get; set; }

        public int Sleeper{ get; set; }


        public DateTime BookingDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string DepartureTime { get; set; }

        public decimal FareAmount { get; set; }
    }

}
