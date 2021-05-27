using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dator.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
