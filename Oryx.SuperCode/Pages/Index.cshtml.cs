using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Oryx.SuperCode.Models.Contents;
using Oryx.SuperCode.Services.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oryx.SuperCode.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        ArticleService articleService;
        CategoryService categoryService;
        public IndexModel(ILogger<IndexModel> logger, ArticleService _articleService, CategoryService _categoryService)
        {
            _logger = logger;
            articleService = _articleService;
            categoryService = _categoryService;
        }
        public List<Article> Articles { get; set; }
        public int ArticleCount { get; set; }
        public List<Category> Categories { get; set; }

        public async Task OnGet(Guid? categoryId)
        {
            Categories = await categoryService.List();

            (Articles, ArticleCount) = categoryId == null ? await articleService.List() : await articleService.List(categoryId.Value);
        }
    }
}
