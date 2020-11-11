using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Context;
using DataLayer.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SampleProject.Models;
using ViewModel.Entities;
namespace SampleProject.Controllers {
    public class HomeController : Controller {

        public static string massage, NewFileName,NewFileName2, NewFileName3,NewFileName5;

        ////////////////////////////////////////////////////////////////////database
        private readonly Context_db db;
        private readonly IWebHostEnvironment env;
        public HomeController (Context_db _db, IWebHostEnvironment _env) {
            db = _db;
            env = _env;
        }

        ////////////////////////////////////////////////////////////////////index
        public IActionResult Index () {
            if (massage != null) {
                ViewBag.msg = massage;
                massage = null;

            }
            return View ();
        }

        ////////////////////////////////////////////////////////////////////list
        public IActionResult list () {
            if (massage != null) {
                ViewBag.msg = massage;
                massage = null;

            }
            ViewBag.list = db.Tbl_Users.OrderByDescending (a => a.Id).ToList ();
            return View ();
        }

        ////////////////////////////////////////////////////////////////////add informations
        public async Task<IActionResult> add (Vm_User vmus) {
            if (db.Tbl_Users.Any (a => a.CodeNational == vmus.CodeNational)) {
                massage = "اطلاعات فردی با این کد ملی قبلا ثبت شده است";
                return RedirectToAction ("index");

            }
            /////upload Image
            string FileExtension1 = Path.GetExtension (vmus.File.FileName);
            NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
            var path = $"{env.WebRootPath}\\Upload\\{NewFileName}";
            using (var stream = new FileStream (path, FileMode.Create)) {

                await vmus.File.CopyToAsync (stream);
            }
            ////end upload Image  


              /////upload file
            string FileExtension2 = Path.GetExtension (vmus.FileUpload.FileName);
            NewFileName2 = String.Concat (Guid.NewGuid ().ToString (), FileExtension2);
            var path2 = $"{env.WebRootPath}\\Upload\\{NewFileName2}";
            using (var stream = new FileStream (path2, FileMode.Create)) {

                await vmus.FileUpload.CopyToAsync (stream);
            }
            ////end upload file  

         /////upload Video
            string FileExtension3 = Path.GetExtension (vmus.VideoUpload.FileName);
            NewFileName3 = String.Concat (Guid.NewGuid ().ToString (), FileExtension3);
            var path3 = $"{env.WebRootPath}\\Upload\\{NewFileName3}";
            using (var stream = new FileStream (path3, FileMode.Create)) {

                await vmus.VideoUpload.CopyToAsync (stream);
            }
            ////end upload Video  



            Tbl_User tbus = new Tbl_User () {
                Name = vmus.Name,
                Family = vmus.Family,
                Age = vmus.Age,
                Address = vmus.Address,
                CodeNational = vmus.CodeNational,
                Image = NewFileName,
                FileName=NewFileName2,
                VideoName=NewFileName3,
                Description=vmus.Description

            };
            db.Tbl_Users.Add (tbus);
            db.SaveChanges ();
            massage = "اطلاعات شما با موفقیت ثبت شد";
            return RedirectToAction ("index");

        }
        ////////////////////////////////////////////////////////////////////delete informations
        public IActionResult del (int id) {
            var deluser = db.Tbl_Users.Where (a => a.Id == id).SingleOrDefault ();
            db.Tbl_Users.Remove (deluser);
            db.SaveChanges ();
            massage = "اطلاعات مورد نظر با موفقیت حذف شد";

            return RedirectToAction ("list");
        }


       
        ////////////////////////////////////////////////////////////////////edit informations
        [HttpGet]
        public IActionResult edit (int id) {

            var edituser = db.Tbl_Users.Where (a => a.Id == id).SingleOrDefault ();
            Vm_User vmus = new Vm_User () {
                Name = edituser.Name,
                Family = edituser.Family,
                Age = edituser.Age,
                Address = edituser.Address,
                CodeNational = edituser.CodeNational,
                Image = edituser.Image,
                FileName=edituser.FileName,
                VideoName=edituser.VideoName
            };

            return View (vmus);
        }

        [HttpPost]
        public async Task<IActionResult> edit (Vm_User vmus) {
            var edituser = db.Tbl_Users.Where (a => a.Id == vmus.Id).SingleOrDefault ();
            edituser.Name = vmus.Name;
            edituser.Family = vmus.Family;
            edituser.Age = vmus.Age;
            edituser.Address = vmus.Address;
            edituser.CodeNational = vmus.CodeNational;

            if (vmus.File != null) {
                /////upload file Image
                string FileExtension1 = Path.GetExtension (vmus.File.FileName);
                NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
                var path = $"{env.WebRootPath}\\Upload\\{NewFileName}";
                using (var stream = new FileStream (path, FileMode.Create)) {

                    await vmus.File.CopyToAsync (stream);
                }
                ////end upload file Image  
                edituser.Image = NewFileName;
            }

            if (vmus.FileUpload != null) {
                /////upload file
                string FileExtension1 = Path.GetExtension (vmus.FileUpload.FileName);
                NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
                var path = $"{env.WebRootPath}\\Upload\\{NewFileName}";
                using (var stream = new FileStream (path, FileMode.Create)) {

                    await vmus.FileUpload.CopyToAsync (stream);
                }
                ////end upload file  
                edituser.FileName = NewFileName;
            }


             if (vmus.VideoUpload != null) {
                /////upload file Video
                string FileExtension1 = Path.GetExtension (vmus.VideoUpload.FileName);
                NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
                var path = $"{env.WebRootPath}\\Upload\\{NewFileName}";
                using (var stream = new FileStream (path, FileMode.Create)) {

                    await vmus.VideoUpload.CopyToAsync (stream);
                }
                ////end upload file Video  
                edituser.VideoName = NewFileName;
            }

            db.Tbl_Users.Update (edituser);
            db.SaveChanges ();
            massage = "اطلاعات شما با موفقیت تغییر یافت";
            return RedirectToAction ("list");

        }
























































//          public IActionResult Profile()
//         {
//             return View();
//         }

//         public async Task<IActionResult> addprofile( Vm_Profile vmpr){

//  /////upload Image
//             string FileExtension5 = Path.GetExtension (vmpr.ImageUpload.FileName);
//             NewFileName5 = String.Concat (Guid.NewGuid ().ToString (), FileExtension5);
//             var path5 = $"{env.WebRootPath}\\Upload\\{NewFileName5}";
//             using (var stream = new FileStream (path5, FileMode.Create)) {

//                 await vmpr.ImageUpload.CopyToAsync (stream);
//             }
//             ////end upload Image  


//             Tbl_Profile tbpr = new Tbl_Profile()
//             {
//               Name=vmpr.Name,
//               User=vmpr.User
              
//             };

            
//             db.Tbl_Profiles.addprofile(tbpr);
//             db.SaveChanges();
//             massage="اطلاعات کاربری شما با موفقیت ثبت شد";







            
//             return View();
//         }

    }
}