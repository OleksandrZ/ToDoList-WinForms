using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoList
{
    public partial class ToDo
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime FinalDate { get; set; }
        public int Priority { get; set; }
        public int StatusId { get; set; }
        public Status status { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Tag> Tags { get; set; }

        public ToDo()
        {
            Tags = new List<Tag>();
        }
    }
}