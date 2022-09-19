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
    public class DeleteModel : PageModel
    {
        private readonly Motelika.Data.MotelikaContext _context;

        public DeleteModel(Motelika.Data.MotelikaContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Motel = await _context.Motel.FindAsync(id);

            if (Motel != null)
            {
                _context.Motel.Remove(Motel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
