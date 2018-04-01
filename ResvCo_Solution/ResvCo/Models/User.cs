using System;
namespace ResvCo.Models
{
    public class User : BaseEntity
    {
        public String UserID { get; set; }
        public String UserName { get; set; }
        public String Role{get;set;}
        public String FacebookUserName{get;set;}
        public String Email{get;set;}
    }
}
