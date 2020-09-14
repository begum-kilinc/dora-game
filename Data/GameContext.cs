using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Game.Models;

namespace Game.Data
{
    public class GameContext : DbContext
    {
        public GameContext()
        {
        }

        public GameContext (DbContextOptions<GameContext> options)
            : base(options)
        {
        }

        public DbSet<Gamer> Gamer { get; set; }
        public DbSet<Hits> Hits { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<Game.Models.HitOwners> HitOwners { get; set; }
        
        

    }
}
