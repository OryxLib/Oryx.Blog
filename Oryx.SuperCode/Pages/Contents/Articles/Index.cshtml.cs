using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Oryx.SuperCode.Data;
using Oryx.SuperCode.Models.Contents;

namespace Oryx.SuperCode.Pages.Contents
{
    public class IndexModel : PageModel
    {
        private readonly Oryx.SuperCode.Data.ApplicationDbContext _context;

        public IndexModel(Oryx.SuperCode.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public async Task OnGetAsync()
        {
            Article = await _context.Articles
                .Include(a => a.Category).ToListAsync();
        }
    }
}
