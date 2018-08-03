using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class Status
    {
        public ApiStatus ApiStatus { get; set; }

        public int StatusCode{ get; set; }

        public string ErrorMessage{ get; set; }
    }
    //ApiStatus will show the status of the status of the booking done 
    public enum ApiStatus
    {
        Success,
        Failure,
        Warning
    }
}