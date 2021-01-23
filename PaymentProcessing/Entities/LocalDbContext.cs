using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Entities
{
    class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentState> PaymentStates { get; set; }
    }
}
