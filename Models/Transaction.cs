using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TravelLove.Models;

namespace TravelLove.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "ID will be automatically generated")]
        public int TransactionId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual RegisterUser RegisterUser { get; set; }

        [ForeignKey("BusId")]
        public int BusId { get; set; }
        public virtual BusDetails BusDetails { get; set; }

        [ForeignKey("charges")]
        public int charges { get; set; }
        public virtual Booking Booking { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required(ErrorMessage = "The bus status cannot be empty.")]
        public string TransactionStatus { get; set; }
    }
}
