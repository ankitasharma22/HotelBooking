using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int NoOfRooms { get; set; }

        public int CodeOfAirport { get; set; }
        public string Address { get; set; }
    }
}