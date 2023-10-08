using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelLove.Models;

namespace TravelLove.Models
{
    public class RegisterUser
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required(ErrorMessage = "Must be atleast 8 characters in length and should contain at least one alphabet, one number and one special character @$!%*#?&")]
        [MinLength(5)]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(50)]

        public string Password { get; set; }
        [MinLength(5)]
        [MaxLength(50)]
        [Required]
        [Compare("Password", ErrorMessage = "password and confirm password are not same")]
        public string ConfirmPassword { get; set; }

       // [Required]
      //  public string usertype { get; set; }

    }
}
