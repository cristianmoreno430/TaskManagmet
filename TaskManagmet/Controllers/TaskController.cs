using Microsoft.AspNetCore.Mvc;
using TaskBussines.Interfaces;

namespace TaskManagmetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {

        private readonly ITasksService _tasksService;
        private readonly ILogger<TaskController> _logger;

        public TaskController(ITasksService tasksService, ILogger<TaskController> logger)
        {
            _tasksService = tasksService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            string task = _tasksService.GetStub(id);
            return Ok(task);

        }
    }
}
