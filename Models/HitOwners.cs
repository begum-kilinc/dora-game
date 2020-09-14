using Game.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Models
{
    public class HitOwners
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GameContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GameContext>>()))
            {
                if (context.Hits.Any())
                {

                    /*var query = context.Hits 
                        .Join(
                            context.Gamer,
                            hits => hits.ShooterID,
                            shooter => shooter.PlayerID,
                            (hits, shooter) => new
                            {
                                ShooterNickName = shooter.NickName
                            }
                        ).ToList();*/
                    // context.Gamer.ToLookup(p=>p.PlayerID==context.Hits.gam)
                   /* var query = from Gamer in context.Set<Gamer>()
                                join hits in context.Set<Hits>()
                                    on Gamer.PlayerID equals  hits.ShooterID  
                                select new { hits, Gamer };*/
                    //context.Gamer.GroupJoin(p=>p.PlayerID==context
                    return;
                }
                context.SaveChanges();
            }
        }
        public string ShooterID { get; set; }
        public string DeadID { get ; set; }
        public string HitZone { get; set; }
        public int ID { get; set; }
        public string HitID { get; set; }
        public string ShooterNickName { get; set; }
    }
}
