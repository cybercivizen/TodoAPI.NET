using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.DTOs {
    public class UserDto {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> TasksTitles { get; set; }
    }
}