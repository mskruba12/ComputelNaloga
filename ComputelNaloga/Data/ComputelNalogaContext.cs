using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ComputelNaloga.Models;

namespace ComputelNaloga.Data
{
    public class ComputelNalogaContext : DbContext
    {
        public ComputelNalogaContext (DbContextOptions<ComputelNalogaContext> options)
            : base(options)
        {
        }

        public DbSet<ComputelNaloga.Models.Car> Car { get; set; } = default!;
    }
}
