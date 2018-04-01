using System;
using System.Collections.Generic;
using ResvCo.Models;
using ResvCo.Models.ViewModels;
namespace ResvCo.Services
{
    public interface IUserMgmtService
    {
        void RegisterNewUser(UserViewModel userData);
        IEnumerable<User> GetListRegisteredUser();
    }
}
