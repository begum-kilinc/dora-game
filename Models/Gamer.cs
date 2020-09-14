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
    public class Gamer
    {
       public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GameContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GameContext>>()))
            {
                if (context.Gamer.Any())
                {
                    return;
                }
                context.SaveChanges();
            }
        }

        public string UserName { get; set; }
        public string NickName { get; set; }
        public int Score { get; set; }
        public int ID { get; set; }
        public int PlayerID { get; set; }
    }
}

