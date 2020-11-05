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

        public static string massage, NewFileName;

        ////////////////////////////////////////////////////////////////////database
        private readonly Context_db db;
        private readonly IHostingEnvironment env;
        public HomeController (Context_db _db, IHostingEnvironment _env) {
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
            /////upload file
            string FileExtension1 = Path.GetExtension (vmus.File.FileName);
            NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
            var path = $"{env.WebRootPath}\\Upload\\{NewFileName}";
            using (var stream = new FileStream (path, FileMode.Create)) {

                await vmus.File.CopyToAsync (stream);
            }
            ////end upload file  

            Tbl_User tbus = new Tbl_User () {
                Name = vmus.Name,
                Family = vmus.Family,
                Age = vmus.Age,
                Address = vmus.Address,
                CodeNational = vmus.CodeNational,
                Image = NewFileName

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
                Image = edituser.Image
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
                /////upload file
                string FileExtension1 = Path.GetExtension (vmus.File.FileName);
                NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
                var path = $"{env.WebRootPath}\\Upload\\{NewFileName}";
                using (var stream = new FileStream (path, FileMode.Create)) {

                    await vmus.File.CopyToAsync (stream);
                }
                ////end upload file  
                edituser.Image = NewFileName;
            }

            db.Tbl_Users.Update (edituser);
            db.SaveChanges ();
            massage = "اطلاعات شما با موفقیت تغییر یافت";
            return RedirectToAction ("list");
        }

    }
}