using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Oryx.SuperCode.Data;
using Oryx.SuperCode.Models.Contents;

namespace Oryx.SuperCode.Pages.Contents.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly Oryx.SuperCode.Data.ApplicationDbContext _context;

        public DetailsModel(Oryx.SuperCode.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
