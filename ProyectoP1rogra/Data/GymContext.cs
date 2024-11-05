using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoP1rogra.Models;

    public class GymContext : DbContext
    {
        public GymContext (DbContextOptions<GymContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoP1rogra.Models.Membresias> Membresias { get; set; } = default!;
    }
