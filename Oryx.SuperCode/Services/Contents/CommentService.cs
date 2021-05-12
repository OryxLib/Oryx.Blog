using Microsoft.EntityFrameworkCore;
using Oryx.SuperCode.Data;
using Oryx.SuperCode.Models.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oryx.SuperCode.Services.Contents
{
    public class CommentService
    {
        ApplicationDbContext dbContext;
        public CommentService(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }

        public async Task Create(Comment comment)
        {
            dbContext.Add(comment);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid commentId)
        {
            dbContext.Remove(new Comment { Id = commentId });
            await dbContext.SaveChangesAsync();
        }

        public async Task<Comment> One(Guid commentId)
        {
            return await dbContext.Comments.FirstOrDefaultAsync(x => x.Id == commentId);
        }

        public async Task<(List<Comment>, int)> List(Guid articleId, int page = 1, int size = 15)
        {
            var query = dbContext.Comments.Where(x => x.ArticleId == articleId);
            var count = await query.CountAsync();
            var data = await query.Skip((page - 1) * size).Take(size).ToListAsync();
            return (data, count);
        }
    }
}
