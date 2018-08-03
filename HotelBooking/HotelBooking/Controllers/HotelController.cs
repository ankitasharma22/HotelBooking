using HotelBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelBooking.Controllers
{

    public class HotelController : ApiController
    {
        //database of existing hotels 
        private static List<Hotel> _hotelList = new List<Hotel>() {
            new Hotel(){Id = 1, Name = "Hotel number 1", NoOfRooms = 5, CodeOfAirport = 440030, Address = "Nagpur"},
            new Hotel(){Id = 2, Name = "Hotel number 2", NoOfRooms = 6, CodeOfAirport = 441100, Address = "Nagpur"}
        };

        [HttpGet]
        public ApiResponse GetHotels()
        {
            try
            {
                return new ApiResponse()
                {
                    Hotels = _hotelList,
                    Status = new Status()
                    {
                        ApiStatus = ApiStatus.Success,
                        ErrorMessage = string.Empty,
                        StatusCode = 15000
                    }
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse()
                {
                    Hotels = null,
                    Status = new Status()
                    {
                        ApiStatus = ApiStatus.Failure,
                        StatusCode = 50012,
                        ErrorMessage = "Please contact admin"
                    }
                };
            }

        }

        [HttpGet]
        public IHttpActionResult GetHotelById(int id)
        {
            var searchResult = _hotelList.SingleOrDefault(_hotelList => _hotelList.Id == id);

            if (searchResult == null)
                return NotFound();
            else
                return Ok(searchResult);
        }

        [HttpPost]
        public IHttpActionResult AddNewHotel([FromBody]Hotel hotel)
        {
            if (!(ModelState.IsValid))
                return BadRequest();
            else
            {
                _hotelList.Add(hotel);
                return Ok();
            }
        }

        public IHttpActionResult DeleteHotelById(int id)
        {


            if (_hotelList.Remove(_hotelList.Find(_hotelList => _hotelList.Id == id)))
                return Ok();
            else
                return NotFound();

        }

        [HttpPut]
        public IHttpActionResult BookRoom(int id, int numberOfRooms)
        {
            Hotel hotel = new Hotel();

            if (_hotelList.Find(_hotelList => _hotelList.Id == id) == null)
                return NotFound();
            else if (_hotelList.Find(_hotelList => _hotelList.Id == id).NoOfRooms >= numberOfRooms)
            {
                _hotelList.Find(_hotelList => _hotelList.Id == id).NoOfRooms -= numberOfRooms;
                return Ok();
            }
            else
                return NotFound();
        }
    }
}

//https://www.c-sharpcorner.com/article/asp-net-web-api-with-fiddler-and-postman/