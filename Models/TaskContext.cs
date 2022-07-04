using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace webapi.Models
{
    public class TaskContext : DbContext
    {
        public DbSet<Category> categories { get; set; }

        public DbSet<Task> tasks { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options): base(options)
        {            
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<Category> categoryList = new List<Category>();
            categoryList.Add(new Category() { CategoryId = Guid.Parse("6e6c25c5-cb99-482d-a89b-2d5f6c7a7640"), Name = "Pending activities", Effort = 20});
            categoryList.Add(new Category() { CategoryId = Guid.Parse("943283c8-49fa-47a5-a28b-7e80780e4d2e"), Name = "Personal activities", Effort = 50});

            List<Task> taskList = new List<Task>();
            taskList.Add(new Task() {TaskId = Guid.Parse("b0f4153b-b754-4a15-bac0-fa0f38abf17e"), 
                                        CategoryId = Guid.Parse("6e6c25c5-cb99-482d-a89b-2d5f6c7a7640"),
                                        PriorityTask = Priority.Medium,
                                        Title = "Payment of public services",
                                        CreationDate = DateTime.Now});
            taskList.Add(new Task() {TaskId = Guid.Parse("e4f1353a-dca2-48cf-bb23-01ca026e6824"), 
                                        CategoryId = Guid.Parse("943283c8-49fa-47a5-a28b-7e80780e4d2e"),
                                        PriorityTask = Priority.Low,
                                        Title = "Finish watching movie",
                                        CreationDate = DateTime.Now}); 

            modelBuilder.Entity<Category>(cat => 
            {
                cat.ToTable("Category");
                cat.HasKey(p => p.CategoryId);

                cat.Property(p => p.Name).IsRequired().HasMaxLength(150);
                cat.Property(p => p.Description).IsRequired(false);
                cat.Property(p => p.Effort);

                cat.HasData(categoryList);
            });

            modelBuilder.Entity<Task>(task =>
            {
                task.ToTable("Task");
                task.HasKey(p => p.TaskId);
                task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);

                task.Property(p => p.Title).IsRequired().HasMaxLength(150);
                task.Property(p => p.Description).IsRequired(false);
                task.Property(p => p.PriorityTask);
                task.Property(p => p.CreationDate);

                task.HasData(taskList);

            });
        }

    }
}