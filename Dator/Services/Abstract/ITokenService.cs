using Dator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dator.Services.Abstract
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
