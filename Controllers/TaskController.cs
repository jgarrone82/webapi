using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        ITaskService taskService;

        public TaskController(ILogger<TaskController> logger, ITaskService service)
        {
            _logger = logger;
            taskService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(taskService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] webapi.Models.Task task)
        {
            taskService.Save(task);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] webapi.Models.Task task)
        {
            taskService.Update(id, task);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            taskService.Delete(id);
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return Error();
        }
    }
}