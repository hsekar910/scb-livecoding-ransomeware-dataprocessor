using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ransomware_dataprocessor.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Ransomware> Ransomwares { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

    }
}
