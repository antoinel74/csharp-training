namespace TodoApi.Models
{
    public class ToDoItem
    {   
        public long Id {get; set;}
        public string? Name {get; set;}
        public bool isComplete {get; set;}
        public string? Secret {get; set;}
    }

    public class ToDoItemDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool isComplete { get; set; }
    }

}
