namespace ToDoApp.Domain.dto.ToDo
{
    public class UpdateToDoRequestDto
    {
        public int id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Completed { get; set; }
    }
}
