using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Motelika.Data;
using Motelika.Model;

namespace Motelika.Pages.Motels
{
    public class DetailsModel : PageModel
    {
        private readonly Motelika.Data.MotelikaContext _context;

        public DetailsModel(Motelika.Data.MotelikaContext context)
        {
            _context = context;
        }

        public Motel Motel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Motel = await _context.Motel.FirstOrDefaultAsync(m => m.ID == id);

            if (Motel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
