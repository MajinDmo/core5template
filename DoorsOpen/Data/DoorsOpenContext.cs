using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DoorsOpen.Models;

namespace DoorsOpen.Data
{
    public class DoorsOpenContext : DbContext
    {
        public DoorsOpenContext (DbContextOptions<DoorsOpenContext> options)
            : base(options)
        {
        }

        public DbSet<DoorsOpen.Models.Blurbinfo> Blurbinfo { get; set; } = default!;
    }
}
