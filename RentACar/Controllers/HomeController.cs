using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACar.Models;
using System.Data;
using Microsoft.AspNet.Identity;

namespace RentACar.Controllers
{
    public class HomeController : Controller
    {
        DbConnection aConnection = new DbConnection();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult InsertRent(string Id, string CarMake, string CarModel, int DaysUse, string DateStart, string DateEnd, int MileageStart, int MileageEnd , double Total)
        {
            double aTotal = 0;
            //Add up Model and Days Use
            if (CarModel == "Compact")
            { aTotal += (19.95 * DaysUse);}
            else if (CarModel == "Standard")
            { aTotal += (24.95 * DaysUse); }
            else
            { aTotal += (39.0 * DaysUse); }

            //Add Milage Used
            var MileageTotal = MileageEnd - MileageStart;
            if(MileageTotal > 0)
            { aTotal += MileageTotal * .32; }

            if(MileageEnd == 0)
            { MileageEnd = MileageStart; }


            

            var UserId = User.Identity.GetUserId();
            ViewBag.Id = UserId;
            ViewBag.CarMake = CarMake;
            ViewBag.CarModel = CarModel;
            ViewBag.DaysUse = DaysUse;
            ViewBag.DateStart = DateStart;
            ViewBag.DateEnd = DateEnd;
            ViewBag.MileageStart = MileageStart;
            ViewBag.MileageEnd = MileageEnd;
            ViewBag.Total = aTotal;

            DbConnection aConnection = new DbConnection();

            aConnection.InsertRent(UserId, CarMake, CarModel, DaysUse, DateStart, DateEnd, MileageStart, MileageEnd, aTotal);

            return View();
        }
        [Authorize]
        public ActionResult InsertRentForm()
        {
            return View();
        }
        [Authorize]
        public ActionResult MyRent(string Id)
        {
            List<Rent> aListOfRent = new List<Rent>();
            aListOfRent = aConnection.GetRent();

            var myRent = from c in aListOfRent
                               where c.Id == Id
                               select c;
            Id = User.Identity.GetUserId();
            ViewBag.ListOfRent = myRent;
            ViewBag.Id = Id;
            return View();
        }
        [Authorize]
        public ActionResult RentDetail(int RentId)
        {
            List<Rent> aListOfRent = new List<Rent>();
            aListOfRent = aConnection.GetRent();

            var rentDetails = from c in aListOfRent
                                  where c.RentId == RentId
                                  select c;

            ViewBag.ListOfRent = rentDetails;
            ViewBag.RentId = RentId;
            return View();
        }
        [Authorize]
        public ActionResult UpdateRent(int RentId,  int DaysUse, string DateStart, string DateEnd, int MileageStart, int MileageEnd, double Total)
        {
            double aTotal = 0;
            //Add Milage Used
            var MileageTotal = MileageEnd - MileageStart;
            if (MileageTotal > 0)
            { aTotal += MileageTotal * .32; }

            if (MileageEnd == 0)
            { MileageEnd = MileageStart; }
            
            //So the end user knows his updates
            ViewBag.RentId = RentId;

            ViewBag.DaysUse = DaysUse;
            ViewBag.DateStart = DateStart;
            ViewBag.DateEnd = DateEnd;
            ViewBag.MileageStart = MileageStart;
            ViewBag.MileageEnd = MileageEnd;
            ViewBag.Total = aTotal;

            //backend
            aConnection.UpdateRent(RentId,DaysUse, DateStart, DateEnd, MileageStart, MileageEnd, aTotal);


            return View();
        }
    }
}