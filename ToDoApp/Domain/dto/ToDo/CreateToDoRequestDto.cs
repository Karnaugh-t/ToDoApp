namespace ToDoApp.Domain.dto.ToDo
{
    public class CreateToDoRequestDto
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool Completed { get; set; }
    }
}
