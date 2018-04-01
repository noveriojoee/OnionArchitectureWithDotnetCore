using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResvCo.Services;
using ResvCo.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResvCo.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserMgmtService _userMgmtService;
        public UsersController(IUserMgmtService injectedServices)
        {
            this._userMgmtService = injectedServices;
        }

        [Route("~/RegisterNewUser")]
        [HttpPost]
        public UserViewModel RegisterNewUser([FromBody]UserViewModel value)
        {
            UserViewModel resultView = new UserViewModel();

            try
            {
                this._userMgmtService.RegisterNewUser(value);
                resultView.ErrorState = "SUCCEED";
            }
            catch (Exception)
            {
                resultView.ErrorState = "FAILED";
            }

            return resultView;
        }

        [Route("~/GetRegisteredUser")]
        [HttpPost]
        public UserViewModel GetRegisteredUser([FromBody]UserViewModel value)
        {
            UserViewModel resultView = new UserViewModel();

            try
            {
                resultView.listRegisteredUser = this._userMgmtService.GetListRegisteredUser();
                resultView.ErrorState = "SUCCEED";
            }
            catch (Exception)
            {
                resultView.ErrorState = "FAILED";
            }

            return resultView;
        }
    }
}
