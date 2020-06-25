using System.Collections.Generic;

namespace ToDoList
{
    public partial class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ToDo> ToDos { get; set; }

        public Tag()
        {
            ToDos = new List<ToDo>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}