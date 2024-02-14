using Microsoft.AspNetCore.Mvc;
using ToDoApp.Domain.dto.ToDo;
using ToDoApp.Domain.interfaces.Auth;
using ToDoApp.Domain.interfaces.ToDo;
using ToDoEntity = ToDoApp.Domain.model.ToDo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.Controllers.ToDo
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private IAddToDoApplication _addToDo;
        private IAuth _auth;

        public ToDoController(IAddToDoApplication addToDo, IAuth auth)
        {
            _addToDo = addToDo;
            _auth = auth;
        }

        // GET: api/<ToDoController>
        [HttpGet]
        public async Task<ActionResult<GetToDosResponseDto>> GetAllToDos()
        {
            List<ToDoEntity>? toDos = await _addToDo.GetToDos();

            if (toDos == null)
            {
                return NotFound(new GetToDoResponseDto { message = "ToDos not found :(", data = null, status = false, Codes = common.GenericResponse.Code.Error });
            }

            return Ok(new GetToDosResponseDto { message = "ToDos :)", data = toDos, status = true, Codes = common.GenericResponse.Code.Success });
        }

        // GET api/<ToDoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetToDoResponseDto>> Get(int id)
        {
            ToDoEntity? toDo = await _addToDo.GetToDo(new GetToDoRequestDto { Id = id });

            if (toDo == null)
            {
                return NotFound(new GetToDoResponseDto { message = "ToDo not found" });
            }


            return Ok(new GetToDoResponseDto { data = toDo, message = "ToDo found" });
        }

        // POST api/<ToDoController>
        [HttpPost("Create")]
        public async Task<ActionResult<CreateToDoResponseDto>> Post([FromBody] CreateToDoRequestDto createToDoRequestDto)
        {
            int insertedId = await _addToDo.CreateToDo(createToDoRequestDto);

            if (insertedId > 0)
            {
                return Ok(new CreateToDoResponseDto { Id = insertedId, message = "ToDo created" });
            }
            return NotFound(new CreateToDoResponseDto { message = "Error creating ToDo" });
        }

        // PUT api/<ToDoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDo(int id,[FromBody] UpdateToDoRequestDto updateToDoRequestDto)
        {
            updateToDoRequestDto.id = id;
            bool created = await _addToDo.UpdateToDo(updateToDoRequestDto);

            if (created)
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteToDoResponseDto>> DeleteToDo(int id)
        {
            if (await _addToDo.DeleteToDo(new DeleteToDoRequestDto { Id = id }))
            {
                return Ok(new DeleteToDoResponseDto { deleteId = id, message = "Todo deleted" });
            }
            return NotFound(new DeleteToDoResponseDto { deleteId = null, message = "error deleting todo" });
        }
    }
}
