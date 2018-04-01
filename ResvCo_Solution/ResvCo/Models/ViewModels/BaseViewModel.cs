using System;
namespace ResvCo.Models.ViewModels
{
    public class BaseViewModel
    {
        public String ErrorCode { get; set; }
        public String ErrorMessage { get; set; }

        public String ErrorState
        {
            set
            {
                if (value == "SUCCEED"){
                    this.ErrorCode = "0000";
                    this.ErrorMessage = "Succeed";
                }else{
                    this.ErrorCode = "9999";
                    this.ErrorMessage = "System Error";
                }
            }
        }
    }
}
