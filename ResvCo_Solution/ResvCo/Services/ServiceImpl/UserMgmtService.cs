using System;
using System.Collections.Generic;
using System.Linq;
using ResvCo.Models;
using ResvCo.Models.ViewModels;
using ResvCo.Repository;

namespace ResvCo.Services.ServiceImpl
{
    public class UserMgmtService : IUserMgmtService
    {
        private IRepository<User> userDAO;

        public UserMgmtService(IRepository<User> userRepository)
        {
            this.userDAO = userRepository;
        }

        public void RegisterNewUser(UserViewModel userData)
        {
            User dataUser = new User();
            dataUser.UserID = Guid.NewGuid().ToString();
            dataUser.UserName = userData.UserName;
            dataUser.Role = "USER";
            dataUser.Email = userData.Email;
            dataUser.FacebookUserName = userData.FacebookUserName;

            this.userDAO.Insert(dataUser);
            this.userDAO.SaveChanges();
        }

        public IEnumerable<User> GetListRegisteredUser()
        {
            IEnumerable<User> result = this.userDAO.GetAll();
            if (result.FirstOrDefault() != null){
                return result;
            }else{
                return new List<User>();
            }
        }
    }
}
