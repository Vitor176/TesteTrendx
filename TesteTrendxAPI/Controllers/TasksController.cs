using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ToDoListAPI.Data.ValueObjects;
using ToDoListAPI.Repository;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private IToDoRepository _repository;
        private readonly Messages.Messages _messages;

        public TasksController(IToDoRepository repository, Messages.Messages messages)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
            _messages = messages ?? throw new ArgumentNullException("Ocorreu um erro interno!");
        }

        /// <summary>
        /// Obtém todas as tasks
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> FindAll()
        {
            try
            {
                Log.Information($"{nameof(TasksController)} - {_messages.BeginRequestMessage(nameof(TasksController))}");
                var tasks = await _repository.FindAll();

                if (tasks.Count() == 0)
                {
                    return NotFound(Messages.Messages.NotFoundDatasForThisRouteMessage);
                }

                return Ok(tasks);
            }
            catch (Exception e)
            {
                Log.Information($"{nameof(TasksController)} - {_messages.ErrorLog(e.ToString())}");
                return BadRequest(Messages.Messages.UnexpectedErrorMessage);
            }

        }
        /// <summary>
        /// Obtém uma task especifíca através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskVO>> FindById(long id)
        {
            try
            {
                var task = await _repository.FindById(id);
                if (task == null) return NotFound(Messages.Messages.NotFoundDataForThisIdMessage);
                return Ok(task);
            }
            catch (Exception e)
            {
                Log.Information($"{nameof(TasksController)} - {_messages.ErrorLog(e.ToString())}");
                return BadRequest(Messages.Messages.UnexpectedErrorMessage);
            }
        }
        /// <summary>
        /// Cria uma nova task
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<TaskVO>> Create(TaskVO vo)
        {
            try
            {
                if (vo == null) return BadRequest(Messages.Messages.ErrorObjectNullMessage);
                var task = await _repository.Create(vo);

                return Ok(task);
            }
            catch (Exception e)
            {
                Log.Information($"{nameof(TasksController)} - {_messages.ErrorCreateTaskIntoDataBase(e.ToString())}");
                return BadRequest(Messages.Messages.UnexpectedErrorMessage);
            }

        }
        /// <summary>
        /// Atualiza uma task já existente, utilizando do id para encontra-la 
        /// </summary>
        /// <param name="vo"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<TaskVO>> Update(TaskVO vo, long id)
        {
            try
            {
                if (vo == null) return BadRequest(Messages.Messages.ErrorObjectNullMessage);
                var task = await _repository.Update(vo, id);
                if (task == null) return BadRequest(Messages.Messages.ErrorUpdateTaskMessage);
                else return Ok("Atualizado com Sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = "Erro interno no servidor.", details = e.Message });
            }

        }
        /// <summary>
        /// Deleta uma task existente pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {

            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
