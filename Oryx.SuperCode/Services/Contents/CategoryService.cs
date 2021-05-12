using Microsoft.EntityFrameworkCore;
using Oryx.SuperCode.Data;
using Oryx.SuperCode.Models.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oryx.SuperCode.Services.Contents
{
    public class CategoryService
    {
        ApplicationDbContext dbContext;
        public CategoryService(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }

        public async Task Create(Category category)
        {
            dbContext.Add(category);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delte(Guid Id)
        {
            dbContext.Remove(new Category { Id = Id });
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Category>> List()
        {
            return await dbContext.Categories.ToListAsync();
        }
    }
}
