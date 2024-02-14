using ToDoApp.Domain.dto.ToDo;
using ToDoEntity = ToDoApp.Domain.model.ToDo;

namespace ToDoApp.Domain.interfaces.ToDo
{
    public interface IAddToDoApplication
    {
        Task<int> CreateToDo(CreateToDoRequestDto createTodoRequest);
        Task<bool> DeleteToDo(DeleteToDoRequestDto deleteToDoRequestDto);
        Task<ToDoEntity?> GetToDo(GetToDoRequestDto getToDoRequestDto);
        Task<List<ToDoEntity>?> GetToDos();
        Task<bool> UpdateToDo(UpdateToDoRequestDto updateToDoRequestDto);
    }
}
