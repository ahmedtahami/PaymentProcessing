using PaymentProcessing.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing
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
