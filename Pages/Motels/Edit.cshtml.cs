using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Motelika.Data;
using Motelika.Model;

namespace Motelika.Pages.Motels
{
    public class EditModel : PageModel
    {
        private readonly Motelika.Data.MotelikaContext _context;

        public EditModel(Motelika.Data.MotelikaContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Motel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotelExists(Motel.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MotelExists(int id)
        {
            return _context.Motel.Any(e => e.ID == id);
        }
    }
}
