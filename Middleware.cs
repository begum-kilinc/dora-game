using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Game.Data;
using Game.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using ServiceReference1;

namespace Game
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            var watch = new Stopwatch();
            watch.Start();
            long second = watch.ElapsedMilliseconds;
            _next = next;
          
        }


        public async Task Invoke(HttpContext httpContext,GameContext _context)
        {            
            SampleService ss = new SampleService();
            int recordlength = 0;
            string recordmessage = "";

            try
            {


                Task<HitDetails[]> task = ss.GethitDetail();
                var hitdetails = task.Result;
                recordlength = hitdetails.Length;


                for (int i = 0; i < hitdetails.Length; i++)
                {
                    Hits hits = new Hits();
                    hits.DeadID =Convert.ToInt32( hitdetails[i].Dead);
                    hits.ShooterID =Convert.ToInt32( hitdetails[i].Shooter);
                    hits.HitID =Guid.Parse( hitdetails[i].HitID);
                    hits.HitZone =Convert.ToInt32( hitdetails[i].HitZone);

                        _context.Hits.Add(hits);
                        // await _context.SaveChangesAsync();
                        Gamer gamer = new Gamer();
                        GamerSample Gs = new GamerSample();
                        Task<GamerDeatils> task2 = Gs.GetGamerDetail(Convert.ToInt32(hitdetails[i].Shooter));
                        var gamerdetails = task2.Result;


                        gamer.PlayerID = Convert.ToInt32(gamerdetails.GamerID);
                        gamer.UserName = gamerdetails.UserName;
                        gamer.Score = Convert.ToInt32(gamerdetails.Score);
                        gamer.NickName = gamerdetails.NickName;

                        _context.Gamer.Add(gamer);
                        Gamer dead = new Gamer();
                        GamerSample GsDead = new GamerSample();
                        Task<GamerDeatils> task3 = Gs.GetGamerDetail(Convert.ToInt32(hitdetails[i].Dead));
                        var deaddetail = task3.Result;

                        dead.PlayerID = Convert.ToInt32(gamerdetails.GamerID);
                        dead.UserName = deaddetail.UserName;
                        dead.Score = Convert.ToInt32(deaddetail.Score);
                        dead.NickName = deaddetail.NickName;
                        _context.Gamer.Add(dead);


                       


                }
            }
            catch (Exception ex)

            {
                recordmessage = ex.Message;
            }
            Logs logs = new Logs();
            logs.RecordCount = recordlength;
            logs.RecordDate = DateTime.Now;
            logs.RecordMessage = recordmessage;
            _context.Logs.Add(logs);
            await _context.SaveChangesAsync();


            /*Gamer gamer = new Gamer();
            GamerSample Gs = new GamerSample();
            Task<GamerDeatils> task2 = Gs.GetGamerDetail();
            var gamerdetails = task2.Result;
            gamer.PlayerID =Convert.ToInt32(gamerdetails.GamerID);
            gamer.UserName = gamerdetails.UserName;
            gamer.Score = Convert.ToInt32(gamerdetails.Score);
            gamer.NickName = gamerdetails.NickName;
            _context.Gamer.Add(gamer);
            await _context.SaveChangesAsync();*/



            // await Task.Delay(TimeSpan.FromSeconds(30), _next);
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
