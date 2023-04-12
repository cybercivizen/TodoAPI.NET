using System.Collections.Generic;
using System.Web.Http;
using BLL.Exceptions;
using DAL.Models;
using BLL.Services;

namespace API.Controllers {
    public class TasksController : ApiController {
        private readonly TasksService service = new TasksService();

        [HttpGet]
        public IHttpActionResult GetTasks() {
            List<Task> tasks= service.GetTasks();
            return Ok(tasks);
        }

        [HttpGet]
        public IHttpActionResult GetTasksByUser(int userId) {
            List <Task> tasks = service.GetTasksByUser(userId);
            return Ok(tasks);
        }

        [HttpGet]
        public IHttpActionResult GetTaskById(int id) {
            Task task = service.GetTaskById(id);
            return Ok(task);
        }

        [HttpPost]
        public IHttpActionResult SaveTask(Task task) {
            try {
                Task savedTask = service.SaveTask(task);

                var routeValues = new { controller = "Tasks", id = savedTask.Id };
                var uri = Url.Link("DefaultApi", routeValues);

                return Created(uri, savedTask);
            }
            catch (InvalidForeignKeyException e) {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete]
        public IHttpActionResult DeleteTasks([FromUri] int[] id) {
            List<Task> deletedTasks = service.DeleteTasks(id);
            if (deletedTasks.Count == 0) return NotFound(); 
            return Ok(deletedTasks);
        }

        [HttpPut]
        public IHttpActionResult UpdateTask(int id, Task task) {
            Task updatedTask = service.UpdateTask(id, task);
            if (updatedTask == null) return NotFound();
            return Ok(updatedTask);
        }
    }
}
