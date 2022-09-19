using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Motelika.Model;

namespace Motelika.Data
{
    public class MotelikaContext : DbContext
    {
        public MotelikaContext (DbContextOptions<MotelikaContext> options)
            : base(options)
        {
        }

        public DbSet<Motelika.Model.Motel> Motel { get; set; }
    }
}
