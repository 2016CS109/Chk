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
            List<Add_Student> person_temp_lst = new List<Add_Student>();
            Database1Entities db = new Database1Entities();
            List<Add_Student> person_list = db.Add_Student.ToList();
            foreach (Add_Student s in person_list)
            {
                person_temp_lst.Add(s);
            }
            return View(person_temp_lst);
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
        [HttpPost]
        public ActionResult UpdateProfile(AdminProfileUpdate item)
        {
            // TODO: Add delete logic here
            using (Database1Entities db = new Database1Entities())
            {
                List<AdminProfileUpdate> contact_list = db.AdminProfileUpdates.ToList();
                foreach (AdminProfileUpdate s in contact_list)
                {
                    db.AdminProfileUpdates.Remove(s);
                    db.SaveChanges();
                }

                db.AdminProfileUpdates.Add(item);
                db.SaveChanges();
                var result = "Successfully added";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult ChangePicture()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePicture(AdminUpdateImagePath item)
        {
            using (Database1Entities db = new Database1Entities())
            {
                List<AdminUpdateImagePath> contact_list = db.AdminUpdateImagePaths.ToList();
                foreach (AdminUpdateImagePath s in contact_list)
                {
                    db.AdminUpdateImagePaths.Remove(s);
                    db.SaveChanges();
                }
                var folderPath = Server.MapPath("~/AppFile/Images");
                System.IO.DirectoryInfo folderInfo = new DirectoryInfo(folderPath);

                foreach (FileInfo file in folderInfo.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in folderInfo.GetDirectories())
                {
                    dir.Delete(true);
                }
                string fileName = Path.GetFileNameWithoutExtension(item.ProfilePic.FileName);
                string extension = Path.GetExtension(item.ProfilePic.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                item.ImagePath = "~/AppFile/Images" + fileName;
                item.ProfilePic.SaveAs(Path.Combine(Server.MapPath("~/AppFile/Images"), fileName));
                db.AdminUpdateImagePaths.Add(item);
                db.SaveChanges();
                var result = "Successfully added";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }






    }
}
