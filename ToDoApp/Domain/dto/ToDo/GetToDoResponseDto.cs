using ToDoApp.common;
using ToDoEntity = ToDoApp.Domain.model.ToDo;

namespace ToDoApp.Domain.dto.ToDo
{
    public class GetToDoResponseDto: GenericResponse
    {
        public ToDoEntity? data { get; set; }
    }
}
