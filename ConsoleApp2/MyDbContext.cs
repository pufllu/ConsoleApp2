using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class MyDbContext : DbContext
    {
        public MyDbContext() : base("DbConnect")
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
