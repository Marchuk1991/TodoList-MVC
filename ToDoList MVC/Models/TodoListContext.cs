using Microsoft.EntityFrameworkCore;

namespace TodoList_MVC.Models
{
    public class TodoListContext : DbContext
    {
        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options) 
        {
        
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Task> Tasks { get; set; }  
    }
}
