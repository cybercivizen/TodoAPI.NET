using System.Collections.Generic;
using System.Web.Http;
using DAL.Models;
using BLL.Services;

namespace API.Controllers {
    public class UsersController : ApiController {
        private readonly UsersService service = new UsersService();

        [HttpGet]
        public IHttpActionResult GetUsers() {
            List<User> users = service.GetUsers();
            return Ok(users);
        }

        [HttpGet]
        public IHttpActionResult GetUserById(int id) {
            User user = service.GetUserById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IHttpActionResult SaveUser(User user) {
            User savedUser = service.SaveUser(user);
            // Getting current URI alongside auto generated ID to create the response.
            var routeValues = new { controller = "Users", id = savedUser.Id };
            var uri = Url.Link("DefaultApi", routeValues);

            return Created(uri, savedUser);
        }

        [HttpPut]
        public IHttpActionResult UpdateUser(int id, User user) {
            User updatedUser = service.UpdateUser(id, user);
            if (updatedUser == null) return NotFound();
            return Ok(updatedUser);
        }

        [HttpDelete]
        public IHttpActionResult DeleteUser(int id) {
            User deletedUser = service.DeleteUser(id);
            if (deletedUser == null) return NotFound();  
            return Ok(deletedUser);
        }
    }
}
