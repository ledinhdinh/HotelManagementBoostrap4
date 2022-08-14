using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementBoostrap4.ViewModel
{
    public class RoomViewModel
    {
        public int RoomID { get; set; }

        [DisplayName("Số Phòng")]
        [Required(ErrorMessage = "Bạn chưa nhập số phòng ! ")]
        public string RoomNumber { get; set; }


        [DisplayName("Chọn Ảnh")]
        [Required(ErrorMessage = "Bạn chưa tải ảnh phòng lên! ")]
        public string RoomImage { get; set; }

        [DisplayName("Giá Phòng")]
        [Required(ErrorMessage = "Bạn chưa nhập giá phòng ! ")]
        [Range(100, 100000, ErrorMessage = "Giá phòng tối thiểu từ 100 - 100tr")]
        public decimal RoomPrice { get; set; }

        [DisplayName("Tình Trạng Phòng")]
        [Required(ErrorMessage = "Bạn chưa nhập tình trạng phòng ! ")]
        public int BookingStatusID { get; set; }

        [DisplayName("Loại Phòng")]
        [Required(ErrorMessage = "Bạn chưa nhập loại phòng ! ")]
        public int RoomTypeID { get; set; }

        [DisplayName("Sức Chứa")]
        [Required(ErrorMessage = "Bạn chưa nhập sức chứa phòng ! ")]
        [Range(1, 8, ErrorMessage = "Sức chứa tối thiểu 1 người.")]
        public int RoomCapacity { get; set; }


        public HttpPostedFileBase Image { get; set; }

        [DisplayName("Mô Tả")]
        [Required(ErrorMessage = "Bạn chưa nhập mô tả phòng ! ")]
        public string RoomDesciption { get; set; }

        //public IEnumerable<Room> Roomsss { get; set; }
        public List<SelectListItem> ListOfBookingStatus { get; set; }
        public List<SelectListItem> ListOfRoomType { get; set; }
    }
}