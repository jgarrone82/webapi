using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Services
{
    public class TaskService : ITaskService
    {
        TaskContext context;
        public TaskService(TaskContext dbcontext)
        {
            context = dbcontext;
        }

        public IEnumerable<webapi.Models.Task> Get()
        {
            return context.tasks;
        }

        public async System.Threading.Tasks.Task Save(webapi.Models.Task task)
        {
            context.Add(task);
            await context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Update(Guid id, webapi.Models.Task task)
        {
            var currentTask = context.tasks.Find(id);

            if (currentTask != null)
            {
                currentTask.CategoryId = task.CategoryId;
                currentTask.Title = task.Title;
                currentTask.PriorityTask = task.PriorityTask;
                currentTask.Description = task.Description;

                await context.SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task Delete(Guid id)
        {
            var currentTask = context.tasks.Find(id);

            if (currentTask != null)
            {
                context.Remove(currentTask);

                await context.SaveChangesAsync();
            }
        }
    }

    public interface ITaskService
    {
        IEnumerable<webapi.Models.Task> Get();
        System.Threading.Tasks.Task Save(webapi.Models.Task task);
        System.Threading.Tasks.Task Update(Guid id, webapi.Models.Task task);
        System.Threading.Tasks.Task Delete(Guid id);
    }
}