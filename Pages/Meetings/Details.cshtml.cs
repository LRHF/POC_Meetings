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
    public class DetailsModel : PageModel
    {
        private readonly POC_Meetings.Data.MeetingsContext _context;

        public DetailsModel(POC_Meetings.Data.MeetingsContext context)
        {
            _context = context;
        }

        public Meeting Meeting { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Meeting = await _context.Meetings.FirstOrDefaultAsync(m => m.Id == id);

            if (Meeting == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
