using System.ComponentModel.DataAnnotations;

namespace TravelLove.Models
{
    public class Refund
    {
        public int RefundId { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]

        public string Email { get; set; }

        [Required]

        public string Contact { get; set; }

        [Required]

        public string Image { get; set; }

        [Required]  

        public int AccountNo { get; set; }

    }
}
