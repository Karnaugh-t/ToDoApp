using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.dto.ToDo;
using ToDoApp.Domain.interfaces.ToDo;
using ToDoApp.Domain.model;

namespace ToDoApp.Infrastructure.persistence.repository.ToDoRepository
{
    public class ToDoRepository: IToDoRepository
    {
        private ApplicationDBContext _dbContext;
        public ToDoRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> InsertToDo(CreateToDoRequestDto createToDoRequestDto)
        {
            ToDo todo = new ToDo {
                Title = createToDoRequestDto.Title,
                Description = createToDoRequestDto.Description,
                Completed = false,
                CreatedAt = DateTime.Now.ToUniversalTime(),
                UpdatedAt = DateTime.Now.ToUniversalTime(),
                UserId = 1,
            };

            _dbContext.ToDo.Add(todo);
            await _dbContext.SaveChangesAsync();
            return todo.Id;
        }

        public async Task<bool> DeleteToDo(DeleteToDoRequestDto deleteToDoRequestDto)
        {
            ToDo ?todoToDelete = await GetToDo(new GetToDoRequestDto { Id = deleteToDoRequestDto.Id });

            if (todoToDelete != null)
            {
                _dbContext.ToDo.Remove(todoToDelete);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return  false;
        }

        public async Task<ToDo?> GetToDo(GetToDoRequestDto getToDoRequestDto)
        {

            ToDo? toDo = await _dbContext.ToDo.FindAsync(getToDoRequestDto.Id);

            if (toDo == null)
            {
                return null;
            }

            return toDo;
        }

        public async Task<List<ToDo>?> GetToDos()
        {
            List<ToDo>? toDos = await _dbContext.ToDo.ToListAsync();

            if (toDos == null)
            {
                return null;
            }

            return toDos;
        }        
        
        public async Task<bool> UpdateToDo(UpdateToDoRequestDto updateToDoRequestDto)
        {
            ToDo ?toDo = await GetToDo(new GetToDoRequestDto { Id= updateToDoRequestDto.id});

            if (toDo == null)
            {
                return false;
            }

            toDo.Title = updateToDoRequestDto.Title;
            toDo.Description = updateToDoRequestDto.Description;
            toDo.Completed = updateToDoRequestDto.Completed;
            toDo.UpdatedAt = DateTime.Now.ToUniversalTime();
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
