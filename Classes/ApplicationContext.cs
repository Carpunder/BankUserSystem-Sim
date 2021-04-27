using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace KursRSPO.Classes
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Operation> Operations { get; set; }

        public ApplicationContext() : base("DefaultConnection") { }

    }
}
