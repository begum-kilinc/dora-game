using Game.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Game.Models
{
    [DataContract]
    public class Hits
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GameContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GameContext>>()))
            {
                if (context.Hits.Any())
                {
                    return;
                }
                context.SaveChanges();
            }
        }
        public int ShooterID { get; set; }
        public int DeadID { get; set; }
        public int HitZone { get; set; }
        public int ID { get; set; }
        public Guid HitID { get; set; }
    }
}
