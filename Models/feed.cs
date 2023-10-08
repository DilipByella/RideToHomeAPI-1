using System.ComponentModel.DataAnnotations;
using TravelLove.Models;

namespace TravelLove.Models
{
    public class feed
    {



        [Key]
        public int feedId { get; set; }
        [Required]
        public string BusName { get; set; }



        public string Text { get; set; }
        [Required]


        public int Rating { get; set; }
    }
}