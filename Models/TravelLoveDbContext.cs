using Microsoft.EntityFrameworkCore;
using TravelLove.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TravelLove
{
    public class TravelLoveDbContext : DbContext
    {

        public TravelLoveDbContext(DbContextOptions<TravelLoveDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> bookings { get; set; }
        public virtual DbSet<BusDetails> Bus { get; set; }
        public DbSet<BusDetails> BusDetails { get; set; }
        public virtual DbSet<feed> Feed { get; set; }
        public virtual DbSet<RegisterUser> Users { get; set; }
      

        public virtual DbSet<BankCred> Bankcred { get; set; }


        public virtual DbSet<Refund> Refund { get; set; }

        public virtual DbSet<Transaction> Transactions{ get; set; }
      








    }
}
