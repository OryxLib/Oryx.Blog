using Microsoft.EntityFrameworkCore;
using Oryx.SuperCode.Data;
using Oryx.SuperCode.Models.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oryx.SuperCode.Services.Contents
{
    public class ArticleService
    {
        ApplicationDbContext dbContext;
        public ArticleService(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }

        public async Task Create(Article article)
        {
            dbContext.Add(article);
            await dbContext.SaveChangesAsync();
        }

        public async Task Edit(Article article)
        {
            dbContext.Update(article);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid Id)
        {
            dbContext.Remove(new Article { Id = Id });
            await dbContext.SaveChangesAsync();
        }

        public async Task<Article> One(Guid articleId)
        {
            return await dbContext.Articles.FirstOrDefaultAsync(x => x.Id == articleId);
        }

        public async Task<(List<Article>, int)> List(Guid categoryId, int page = 1, int size = 15)
        {
            var query = dbContext.Articles.Where(x => x.CategoryId == categoryId);
            var count = await query.CountAsync();
            var data = await query.Skip((page - 1) * size).Take(size).ToListAsync();
            return (data, count);
        }

        public async Task<(List<Article>, int)> List(string key, int page = 1, int size = 15)
        {
            var query = dbContext.Articles.Where(x => x.Title == key || x.Description.Contains(key) || x.Content.Contains(key));
            var count = await query.CountAsync();
            var data = await query.Skip((page - 1) * size).Take(size).ToListAsync();
            return (data, count);
        }

        public async Task<(List<Article>, int)> List(int page = 1, int size = 15)
        {
            var query = dbContext.Articles;
            var count = await query.CountAsync();
            var data = await query.Skip((page - 1) * size).Take(size).ToListAsync();
            return (data, count);
        }
    }
}
