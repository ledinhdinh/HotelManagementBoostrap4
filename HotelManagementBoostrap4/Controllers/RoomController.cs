using HotelManagementBoostrap4.Models;
using HotelManagementBoostrap4.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementBoostrap4.Controllers
{
    public class RoomController : Controller
    {
        Hotel_DataEntities db = new Hotel_DataEntities();


        // GET: Room
        [HttpGet]
        public ActionResult Index()
        {
            var roomViewModel = new RoomViewModel();

            roomViewModel.ListOfBookingStatus = (from obj in db.BookingStatus
                                                 select new SelectListItem()
                                                 {
                                                     Text = obj.BookingStatus,
                                                     Value = obj.BookingStatusID.ToString()
                                                 }).ToList();

            roomViewModel.ListOfRoomType = (from obj in db.RoomTypes
                                            select new SelectListItem()
                                            {
                                                Text = obj.RoomTypeName,
                                                Value = obj.RoomTypeID.ToString()
                                            }).ToList();

            return View(roomViewModel);
        }

        [HttpPost]
        public ActionResult Index(RoomViewModel roomViewModel)
        {
            if (roomViewModel.RoomID == 0)
            {
                string ImageUniqueName = Guid.NewGuid().ToString();
                string ActualImageName = ImageUniqueName + Path.GetExtension(roomViewModel.Image.FileName);
                roomViewModel.Image.SaveAs(Server.MapPath("~/ImageRoom/" + ActualImageName));

                Room room = new Room()
                {
                    RoomNumber = roomViewModel.RoomNumber,
                    RoomPrice = roomViewModel.RoomPrice,
                    RoomImage = ActualImageName,
                    BookingStatusID = roomViewModel.BookingStatusID,
                    RoomTypeID = roomViewModel.RoomTypeID,
                    RoomDesciption = roomViewModel.RoomDesciption,
                    RoomCapacity = roomViewModel.RoomCapacity,
                    IsActive = true
                };
                db.Rooms.Add(room);
                //message = "Added";
            }
            else
            {
                Room room = db.Rooms.Single(model => model.RoomID == roomViewModel.RoomID);
                if (roomViewModel.Image != null)
                {
                    string ImageUniqueName = Guid.NewGuid().ToString();
                    string ActualImageName = ImageUniqueName + Path.GetExtension(roomViewModel.Image.FileName);
                    roomViewModel.Image.SaveAs(Server.MapPath("~/ImageRoom/" + ActualImageName));
                    room.RoomImage = ActualImageName;
                }
                room.RoomNumber = roomViewModel.RoomNumber;
                room.RoomPrice = roomViewModel.RoomPrice;
                room.BookingStatusID = roomViewModel.BookingStatusID;
                room.RoomTypeID = roomViewModel.RoomTypeID;
                room.RoomDesciption = roomViewModel.RoomDesciption;
                room.RoomCapacity = roomViewModel.RoomCapacity;
                room.IsActive = true;
                //message = "Updated";
            }

            db.SaveChanges();
            return RedirectToAction("Index");
            // return Json(new { message = "Room Successfully" + message, success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public PartialViewResult GetRoomAll()
        {
            IEnumerable<RoomDetailModel> listOfRoomDetailViewModels = (from room in db.Rooms
                                                                       join objBooking in db.BookingStatus on room.BookingStatusID equals objBooking.BookingStatusID
                                                                       join objRoomType in db.RoomTypes on room.RoomTypeID equals objRoomType.RoomTypeID
                                                                       where room.IsActive == true
                                                                       select new RoomDetailModel()
                                                                       {
                                                                           RoomNumber = room.RoomNumber,
                                                                           RoomPrice = room.RoomPrice,
                                                                           RoomImage = room.RoomImage,
                                                                           BookingStatus = objBooking.BookingStatus,
                                                                           RoomType = objRoomType.RoomTypeName,
                                                                           RoomDesciption = room.RoomDesciption,
                                                                           RoomCapacity = room.RoomCapacity,
                                                                           RoomID = room.RoomID
                                                                       }).ToList();

            return PartialView("_RoomDetailView", listOfRoomDetailViewModels);
        }

        [HttpGet]
        public JsonResult EditRoomDetail(int roomID)
        {
            var result = db.Rooms.Single(model => model.RoomID == roomID);
            // return RedirectToAction("Index");
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DeleteRoomDetail(int roomID)
        {
            Room room = db.Rooms.Single(model => model.RoomID == roomID);
            room.IsActive = false;
            db.SaveChanges();
            return Json(new { message = "Đã xóa 1 phòng thành công", success = true }, JsonRequestBehavior.AllowGet);
        }
        /*[HttpGet]
         public ActionResult GetRoomDetail(int roomID)
         {
             var detailRoom = db.Rooms.Where(model => model.RoomID == roomID).FirstOrDefault();
             return View(detailRoom);
         }*/
    }
}
 