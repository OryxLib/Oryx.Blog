using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Oryx.SuperCode.Models.Contents;
using Oryx.SuperCode.Services.Contents;

namespace Oryx.SuperCode.Pages.Contents
{
    public class CreateArticlePageModel : PageModel
    {
        ArticleService articleService;
        public CreateArticlePageModel(ArticleService _articleService)
        {
            articleService = _articleService;
        }
        public void OnGet()
        {
        }

        public async Task OnPost(Article article)
        {
            await articleService.Create(article);
        }
    }
}
