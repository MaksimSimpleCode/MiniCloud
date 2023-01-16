using Domain;
using Microsoft.AspNetCore.Mvc;
using MiniCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        Task<IActionResult> Register(UserModel userModel);
        IEnumerable<User> GetAll();
        User GetById(Guid id);
    }
}
