using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Services
{
    public class CategoryService : ICategoryService
    {
        TaskContext context;

        public CategoryService(TaskContext dbcontext)
        {
            context = dbcontext;
        }
        public IEnumerable<Category> Get()
        {
            return context.categories;
        }

        public async System.Threading.Tasks.Task Save(Category category)
        {
            context.Add(category);
            await context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Update(Guid id, Category category)
        {
            var currentCategory = context.categories.Find(id);

            if (currentCategory != null)
            {
                currentCategory.Name = category.Name;
                currentCategory.Description = category.Description;
                currentCategory.Effort = category.Effort;

                await context.SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task Delete(Guid id)
        {
            var currentCategory = context.categories.Find(id);

            if (currentCategory != null)
            {
                context.Remove(currentCategory);

                await context.SaveChangesAsync();
            }
        }
    }

    public interface ICategoryService
    {
        IEnumerable<Category> Get();
        System.Threading.Tasks.Task Save(Category category);
        System.Threading.Tasks.Task Update(Guid id, Category category);
        System.Threading.Tasks.Task Delete(Guid id);

    }
}