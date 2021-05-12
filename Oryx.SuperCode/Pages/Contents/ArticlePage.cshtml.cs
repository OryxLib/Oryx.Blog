using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Oryx.SuperCode.Models.Contents;
using Oryx.SuperCode.Services.Contents;

namespace Oryx.SuperCode.Pages.Contents
{
    public class ArticlePageModel : PageModel
    {
        ArticleService articleService;
        CommentService commentService;
        UserManager<IdentityUser> userManager;
        public ArticlePageModel(ArticleService _articleService, CommentService _commentService, UserManager<IdentityUser> _userManager)
        {
            articleService = _articleService;
            commentService = _commentService;
            userManager = _userManager;
        }

        public Article ArticleData { get; set; }
        public List<Comment> Comments { get; set; }
        public int CommentCount { get; set; }

        public async Task OnGet(Guid articleId)
        {
            ArticleData = await articleService.One(articleId);
            (Comments, CommentCount) = await commentService.List(articleId);
        }


        public async Task<ActionResult> OnPostCommentCreateAsync(Comment comment)
        {
            var userId = User?.Claims?.FirstOrDefault(x => x.Type.Contains("nameidentifier"))?.Value;
            if (userId == null)
            {
                return Redirect("/Identity/Account/Login");
            }
            var user = await userManager.FindByIdAsync(userId);
            comment.AuthorId = userId;
            comment.AuthorName = user.UserName;
            await commentService.Create(comment);
            return Page();
        }


        public async Task OnGetCommentListAsync(Guid articleId, int page = 1, int size = 15)
        {
            (Comments, CommentCount) = await commentService.List(articleId, page, size);
        }
    }
}
