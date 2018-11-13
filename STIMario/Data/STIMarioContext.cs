using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using STIMario.Models;

namespace STIMario.Models
{
    public class STIMarioContext : DbContext
    {
        public STIMarioContext (DbContextOptions<STIMarioContext> options)
            : base(options)
        {
        }

        public DbSet<STIMario.Models.Ejercicios> Ejercicios { get; set; }

        public DbSet<STIMario.Models.Resultados> Resultados { get; set; }
    }
}
