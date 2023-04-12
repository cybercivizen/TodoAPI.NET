using System;

namespace BLL.Exceptions {
    public class InvalidForeignKeyException: Exception {
        public InvalidForeignKeyException(string message): base(message) { }
    }
}