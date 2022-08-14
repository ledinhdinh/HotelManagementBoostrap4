using HotelManagementBoostrap4.Models;
using HotelManagementBoostrap4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementBoostrap4.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        Hotel_DataEntities db = new Hotel_DataEntities();
        // GET: Booking
        public ActionResult Index()
        {
            BookingViewModel bookingViewModel = new BookingViewModel();
            bookingViewModel.ListOfRooms = (from room in db.Rooms
                                            where room.BookingStatusID == 2

                                            select new SelectListItem()
                                            {
                                                Text = room.RoomNumber,
                                                Value = room.RoomID.ToString()
                                            }).ToList();
            bookingViewModel.BookingFrom = DateTime.Now;
            bookingViewModel.BookingTo = DateTime.Now.AddDays(1);

            return View(bookingViewModel);
        }
        [HttpPost]
        public ActionResult Index(BookingViewModel bookingViewModel)
        {
            int numberOfDays = Convert.ToInt32((bookingViewModel.BookingTo - bookingViewModel.BookingFrom).TotalDays);
            Room room = db.Rooms.Single(model => model.RoomID == bookingViewModel.AssignRoomID);
            decimal RoomPrice = room.RoomPrice;
            decimal TotalAmount = RoomPrice * numberOfDays;

            RoomsBooking roomsBooking = new RoomsBooking()
            {
                CustomerName = bookingViewModel.CustomerName,
                CustomerAddress = bookingViewModel.CustomerAddress,
                CustomerPhone = bookingViewModel.CustomerPhone,
                BookingFrom = bookingViewModel.BookingFrom,
                BookingTo = bookingViewModel.BookingTo,
                AssignRoomID = bookingViewModel.AssignRoomID,
                NumberOfMembers = bookingViewModel.NumberOfMembers,
                TotalAmount = TotalAmount
            };
            db.RoomsBookings.Add(roomsBooking);
            db.SaveChanges();

            room.BookingStatusID = 3;
            db.SaveChanges();

            //return Json("",JsonRequestBehavior.AllowGet);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult GetAllBooking()
        {
            List<BookingDetailModel> roomBookingViewModels = new List<BookingDetailModel>();
            roomBookingViewModels = (from roomsBooking in db.RoomsBookings
                                     join room in db.Rooms on roomsBooking.AssignRoomID equals room.RoomID
                                     select new BookingDetailModel()
                                     {
                                         BookingFrom = roomsBooking.BookingFrom,
                                         BookingTo = roomsBooking.BookingTo,
                                         CustomerName = roomsBooking.CustomerName,
                                         CustomerPhone = roomsBooking.CustomerPhone,
                                         CustomerAddress = roomsBooking.CustomerAddress,
                                         TotalAmount = roomsBooking.TotalAmount,
                                         NumberOfMembers = roomsBooking.NumberOfMembers,
                                         BookingID = roomsBooking.BookingID,
                                         RoomNumber = room.RoomNumber,
                                         RoomPrice = room.RoomPrice,
                                         NumberOfDays = System.Data.Entity.DbFunctions.DiffDays(roomsBooking.BookingFrom,roomsBooking.BookingTo).Value
                                     }).ToList();

            return PartialView("_BookingDetailView", roomBookingViewModels);
        }
    } 
}