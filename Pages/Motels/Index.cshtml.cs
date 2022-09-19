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
    public class IndexModel : PageModel
    {
        private readonly Motelika.Data.MotelikaContext _context;

        public IndexModel(Motelika.Data.MotelikaContext context)
        {
            _context = context;
        }

        public IList<Motel> Motel { get;set; }

        public async Task OnGetAsync()
        {
            Motel = await _context.Motel.ToListAsync();
        }
    }
}
