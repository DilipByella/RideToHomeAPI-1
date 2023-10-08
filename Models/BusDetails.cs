using System;
using TravelLove.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelLove.Models
{
    public class BusDetails
    {
        [Key]
        public int BusId { get; set; }
        [Required]
        public string BusName { get; set; }
        [Required]
        public string Source { get; set; }
     
      

        [Required]
        public string Destination { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        public string DepartureTime { get; set; }
        [Required]
        public int charges { get; set; }
        [Required(ErrorMessage = "Enter the number of seats for First AC")]
        public int FirstAC { get; set; }

        [Required(ErrorMessage = "Enter the number of seats for First AC")]

        public int FirstACPrice { get; set; }



        [Required(ErrorMessage = "Enter the number of seats for Second AC")]
        public int SecondAC { get; set; }


        [Required(ErrorMessage = "Enter the number of seats for Second AC")]
        public int SecondACPrice { get; set; }

        [Required(ErrorMessage = "Enter the number of seats for Sleeper")]
        public int Sleeper { get; set; }

        [Required(ErrorMessage = "Enter the total number of seats ")]

        public int SleeperPrice{ get; set; }
        public string Image { get; set; }

        [Required(ErrorMessage = "Enter the total number of seats ")]
        public int Total { get; set; }


    }
}
