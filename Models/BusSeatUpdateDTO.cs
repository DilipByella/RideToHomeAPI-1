using System.ComponentModel.DataAnnotations;

namespace TravelLove.Models
{
    public class BusSeatUpdateDTO
    {
        [Required]
        public int BusId { get; set; }

       

        public int FirstAC { get; set; }

        

        public int SecondAC { get; set; }


        public int Sleeper { get; set; }
    }
}
