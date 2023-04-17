using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TodoList_MVC.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeadLine { get; set; }
        public bool Completed { get; set; }

        public int CategoryId { get; set; }

        [ValidateNever]
        public Category Category { get; set; }
    }

}
