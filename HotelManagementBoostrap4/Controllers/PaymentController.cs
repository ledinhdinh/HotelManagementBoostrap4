using HotelManagementBoostrap4.Models;
using HotelManagementBoostrap4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementBoostrap4.Controllers
{
    public class PaymentController : Controller
    {
        Hotel_DataEntities db = new Hotel_DataEntities();
        // GET: Payment
        public ActionResult Index()
        {
            PaymentViewModel paymentViewModel = new PaymentViewModel();
            paymentViewModel.ListOfBooking = (from room in db.Rooms
                                              select new SelectListItem()
                                              {
                                                  Text = room.RoomNumber,
                                                  Value = room.RoomID.ToString()
                                              }).ToList();
            paymentViewModel.ListOfPaymentType = (from obj in db.PaymentTypes
                                                  select new SelectListItem()
                                                  {
                                                      Text = obj.PaymentTypeName,
                                                      Value = obj.PaymenTypeID.ToString()
                                                  }).ToList();
            paymentViewModel.RoomsBookings =db.RoomsBookings.ToList();
            return View(paymentViewModel);
        }
   
    }
}