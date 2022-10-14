using System;
using System.Collections.Generic;
using System.Linq;
using classwebsite.Model;
using classwebsite.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace classwebsite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        public TasksController(JsonFileTaskService TaskService) => this.TaskService = TaskService;

        public JsonFileTaskService TaskService { get; }

        [HttpGet]
        public IEnumerable<Task> Get() => TaskService.GetTasks();

    }

}