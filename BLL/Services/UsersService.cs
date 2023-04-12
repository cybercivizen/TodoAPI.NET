using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Data;
using DAL.Models;

namespace BLL.Services {
    public class UsersService {
        private readonly TodoListContext context = new TodoListContext();

        public List<User> GetUsers() {
            return context.Users.Include("Tasks").ToList();
        }

        public User GetUserById(int id) {
            return context.Users.Find(id);
        }

        public User SaveUser(User user) {
            User savedUser = context.Users.Add(user);
            context.SaveChanges();
            return savedUser;
        }

        public User UpdateUser(int id, User user) {
            User userToUpdate = context.Users.Find(id);
            if (userToUpdate != null) {
                if (!string.IsNullOrEmpty(user.Name))
                    userToUpdate.Name = user.Name;

                if (!string.IsNullOrEmpty(user.Email))
                    userToUpdate.Email = user.Email;

                if (!string.IsNullOrEmpty(user.PasswordHash))
                    userToUpdate.PasswordHash = user.PasswordHash;

                context.SaveChanges();
            }
            return userToUpdate;
        }

        public User DeleteUser(int id) {
            User userToDelete = context.Users.Find(id);
            if (userToDelete != null) {
                context.Users.Remove(userToDelete);
                context.SaveChanges();
            }
            return userToDelete;
        }


    }
}