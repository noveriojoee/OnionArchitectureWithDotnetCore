using System;
using System.Collections.Generic;

namespace ResvCo.Models.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public String UserName { get; set; }
        public String FacebookUserName { get; set; }
        public String Email { get; set; }

        public IEnumerable<User> listRegisteredUser { get; set; }
    }
}
