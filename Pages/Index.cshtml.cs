using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Game.Data;
using Game.Models;


namespace Game.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Game.Data.GameContext _context;
        public string CurrentFilter { get; set; }
        public IndexModel(Game.Data.GameContext context)
        {

            _context = context;
        }

        public IList<Logs> Logs { get;set; }
        public PaginatedList<Logs> Paged { get; set; }
        public async Task OnGetAsync(string currentFilter,int? pageIndex)
        {
            if(pageIndex==null)
            { pageIndex = 1;
            }
            // gameController cs = new gameController(_context);
            // cs.Index();
            if (currentFilter != null)
            {
                pageIndex = 1;
            }
            IQueryable<Logs> listim = from s in _context.Logs
                                             select s;

            Logs = await _context.Logs.ToListAsync();
           int pageSize = 10;
            Paged = await PaginatedList<Logs>.CreateAsync(
                listim.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
