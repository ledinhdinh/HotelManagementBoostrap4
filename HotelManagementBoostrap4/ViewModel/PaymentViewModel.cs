using HotelManagementBoostrap4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementBoostrap4.ViewModel
{
    public class PaymentViewModel
    {
        public int PaymentID { get; set; }
        [DisplayName("Số Phòng")]
        public int BookingID { get; set; }
        [DisplayName("Hình Thức Thanh Toán")]
        public int PaymentTypeID { get; set; }
        [DisplayName("Tổng Tiền")]
        public decimal PaymentAmount { get; set; }

        public List<SelectListItem> ListOfPaymentType { get; set; }
        public IEnumerable<SelectListItem> ListOfBooking { get; set; }
        public IEnumerable<RoomsBooking> RoomsBookings { get; set; }

    }
}