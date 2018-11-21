using Campus_Social_Network.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Campus_Social_Network.Controllers
{
    public class AdminController : Controller
    {
        
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddStudent()
        {
            return View();
        }

        public ActionResult SaveData(Add_Student item)
        {
            //if(item.FirstName != null && item.LastName != null && item.DateOfBirth != null && item.ProfilePic != null && item.RegisterationNumber != null && item.Class != null && item.Email != null && item.Password != null)
            //{

            //}
            Database1Entities db = new Database1Entities();
            string fileName = Path.GetFileNameWithoutExtension(item.ProfilePic.FileName);
            string extension = Path.GetExtension(item.ProfilePic.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
            item.PicUrl = "~/AppFile/Images" + fileName;
            item.ProfilePic.SaveAs(Path.Combine(Server.MapPath("~/AppFile/Images"), fileName));
            using (db)
            {
                db.Add_Student.Add(item);
                db.SaveChanges();
                var result = "Successfully added";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddTeacher()
        {
            return View();
        }

        public ActionResult AddClass()
        {
            return View();
        }

        public ActionResult AllStudents()
        {
            return View();
        }

        public ActionResult AllTeachers()
        {
            return View();
        }

        public ActionResult AllClasses()
        {
            return View();
        }

        public ActionResult UpdateProfile()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult ChangePicture()
        {
            return View();
        }





    }
}
