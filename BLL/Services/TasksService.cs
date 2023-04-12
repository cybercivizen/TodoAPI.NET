using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Exceptions;
using DAL.Models;

namespace BLL.Services {
    public class TasksService {
        private readonly TodoListContext context = new TodoListContext();

        public List<Task> GetTasks() {
            return context.Tasks.ToList();
        }

        public Task GetTaskById(int id) {
            return context.Tasks.Find(id);
        }

        public List<Task> GetTasksByUser(int? id) {
            return context.Tasks.Where(t => t.UserId == id).ToList();
        }

        public Task SaveTask(Task task) {
            User associatedUser = context.Users.Find(task.UserId);
            if (associatedUser == null) throw new InvalidForeignKeyException("Invalid user ID");

            Task savedTask = context.Tasks.Add(task);
            context.SaveChanges();

            return savedTask;
        }

        public Task DeleteTask(int id) {
            Task taskToDelete = context.Tasks.Find(id);
            if (taskToDelete != null) {
                context.Tasks.Remove(taskToDelete);
                context.SaveChanges();
            }
            return taskToDelete;
        }

        public List<Task> DeleteTasks(int[] ids) {
            List<Task> tasksToDelete = new List<Task>();
            foreach(int id in ids) {
                Task task = context.Tasks.Find(id);
                if (task != null)
                    tasksToDelete.Add(task);
            }
            context.Tasks.RemoveRange(tasksToDelete);
            context.SaveChanges();
            return tasksToDelete;
        }

        public Task UpdateTask(int id, Task task) {
            Task taskToUpdate = context.Tasks.Find(id);
            if (taskToUpdate != null) {
                if (!string.IsNullOrEmpty(task.Title))
                    taskToUpdate.Title = task.Title;

                if (!string.IsNullOrEmpty(task.Description))
                    taskToUpdate.Description = task.Description;

                if (!DateTime.MinValue.Equals(task.DueDate))
                    taskToUpdate.DueDate = task.DueDate;

                taskToUpdate.IsCompleted = task.IsCompleted;

                context.SaveChanges();
            }
            return taskToUpdate;
        }


    }
}