using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using POC_Meetings.Data;
using POC_Meetings.Models;

namespace POC_Meetings.Pages.Meetings
{
    public class IndexModel : PageModel
    {
        private readonly MeetingsContext _context;
        public string _searchString { get; set; } = "";

        public IndexModel(MeetingsContext context)
        {
            _context = context;
        }

        public IList<Meeting> Meeting { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            _searchString = searchString;
            IQueryable<Meeting> meetingsIQ = from m in _context.Meetings select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                meetingsIQ = meetingsIQ.Where(m => m.CompanyName.Contains(searchString) || m.ContactName.Contains(searchString));
            }

            Meeting = await meetingsIQ.ToListAsync();
        }

    }
}
