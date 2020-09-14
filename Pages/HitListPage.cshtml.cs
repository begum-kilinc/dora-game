using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Game.Data;
using Game.Models;
using ServiceReference1;

namespace Game.Pages
{
    public class HitListPageModel : PageModel
    {
        private readonly Game.Data.GameContext _context;

        public HitListPageModel(Game.Data.GameContext context)
        {
            _context = context;
        }
        public string CurrentFilter { get; set; }
        public PaginatedList<Hits> Paged { get; set; }
        public IList<Hits> Hits { get;set; }
        public IList<Gamer> Gamer { get; set; }
        public string shootername { get; set; }
        public IQueryable<Gamer> gamerinstance;
        public async Task OnGetAsync(string currentFilter, int? pageIndex)
        {
            gamerinstance = from s in _context.Gamer
                                             select s;
            if (pageIndex == null)
            {
                pageIndex = 1;
            }
            // gameController cs = new gameController(_context);
            // cs.Index();
            if (currentFilter != null)
            {
                pageIndex = 1;
            }
            IQueryable<Hits> listim = from s in _context.Hits
                                      select s;

            /*foreach (var item in Paged)
            {


                gamerinstance = gamerinstance.Where(s => s.PlayerID == item.ShooterID);

                Paged[0].ShooterID = gamerinstance.First().PlayerID;
            }*/
            // Gamer = gamerinstance.AsNoTracking();

            //Gamer=await _context.Hits.ToLookup(),
            Gamer = await _context.Gamer.ToListAsync();
            Hits = await _context.Hits.ToListAsync();
            Paged = await PaginatedList<Hits>.CreateAsync(listim.AsNoTracking(), pageIndex ?? 1, 10);
            
        }
    }
}
