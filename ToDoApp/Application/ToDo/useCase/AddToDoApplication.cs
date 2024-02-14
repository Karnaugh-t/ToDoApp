using ToDoApp.Domain.dto.ToDo;
using ToDoApp.Domain.interfaces.ToDo;
using ToDoEntity = ToDoApp.Domain.model.ToDo;

namespace ToDoApp.Application.ToDo.useCase
{
    public class AddToDoApplication : IAddToDoApplication
    {
        private IToDoRepository _repository;
        public AddToDoApplication(IToDoRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateToDo(CreateToDoRequestDto createTodoRequest)
        {
            return await _repository.InsertToDo(createTodoRequest);
        }

        public async Task<bool> DeleteToDo(DeleteToDoRequestDto deleteToDoRequestDto)
        {
            return await _repository.DeleteToDo(deleteToDoRequestDto);
        }

        public async Task<ToDoEntity?> GetToDo(GetToDoRequestDto getToDoRequestDto)
        {
            return await _repository.GetToDo(getToDoRequestDto);
        }       
        public async Task<List<ToDoEntity>?> GetToDos()
        {
            return await _repository.GetToDos();
        }

        public async Task<bool> UpdateToDo(UpdateToDoRequestDto updateToDoRequestDto)
        {
            return await _repository.UpdateToDo(updateToDoRequestDto);
        }
    }
}
