using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementBoostrap4.ViewModel
{
    public class BookingViewModel
    {
        public int BookingID { get; set; }
        [Display(Name = " Tên Khách Hàng")]
        [Required(ErrorMessage = "Bạn chưa nhập tên khách hàng !")]
        public string CustomerName { get; set; }

        [Display(Name = "Địa Chỉ Khách Hàng")]
        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ khách hàng !")]
        public string CustomerAddress { get; set; }

        [Display(Name = "Căn Cước Công Dân")]
        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại !")]
        public string CustomerPhone { get; set; }

        [Display(Name = "Ngày Đặt Phòng")]
        [Required(ErrorMessage = "Bạn chưa nhập ngày đặt phòng !")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BookingFrom { get; set; }

        [Display(Name = "Ngày Trả Phòng")]
        [Required(ErrorMessage = "Bạn chưa nhập ngày trả phòng !")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BookingTo { get; set; }

        [Display(Name = "Số Phòng")]
        [Required(ErrorMessage = "Bạn chưa chọn số phòng !")]
        public int AssignRoomID { get; set; }

        [Display(Name = "Số Lượng Khách")]
        [Required(ErrorMessage = "Bạn chưa nhập số lượng khách hàng !")]
        public int NumberOfMembers { get; set; }

        public decimal TotalAmount { get; set; }

        public IEnumerable<SelectListItem> ListOfRooms { get; set; }
    }
}