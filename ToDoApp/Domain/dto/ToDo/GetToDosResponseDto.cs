using ToDoApp.common;
using ToDoEntity = ToDoApp.Domain.model.ToDo;

namespace ToDoApp.Domain.dto.ToDo
{
    public class GetToDosResponseDto: GenericResponse
    {
        public List<ToDoEntity>? data { get; set; } = null!;
    }
}
