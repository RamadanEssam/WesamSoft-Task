using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WesamTask.DAL.Entities;

namespace WesamTask.DAL.DataBase
{
    public class DbContainer : DbContext  // context
    {
        public DbContainer(DbContextOptions <DbContainer> opts):base (opts)
        {
                
        }

        public DbSet<Employee> Employee { get; set; }

    }
}
