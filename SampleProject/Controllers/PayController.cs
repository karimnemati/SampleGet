using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using DataLayer.Context;
using DataLayer.Entities;
using Dto.Payment;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Entities;
using ZarinPal.Class;

namespace Sample.Controllers {
    ////////////////////////////////////////////////////////////////////database
        public class PayController : Controller {
        public static int amount1, id;
        public static string massage;
        private readonly Context_db db;
        private readonly IWebHostEnvironment env;
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        public static string msg;
        public PayController (Context_db _db, IWebHostEnvironment _env) {
            var expose = new Expose ();
            _payment = expose.CreatePayment ();
            _authority = expose.CreateAuthority ();
            _transactions = expose.CreateTransactions ();

            db = _db;
            env = _env;
        }

        /////////////////////////////////////////////////////////////////////

        public IActionResult Index () {

            if (msg != null) {
                ViewBag.msg = msg;
                msg = null;
            }

            return View ();
        }
        //////////////////////////////////////////////////////////////////////Request

        ///////////////////////////////////////////////////////////////////////////////////Add Request Informations

        public async Task<IActionResult> Request (Vm_Pay model) {

            var tb = new Tbl_Pay () {
                Name = model.Name,
                Email = model.Email,
                Amonnt = model.Amonnt,
                Tel = model.Tel,
                Date = DateTime.Today,
                Status = false,
            };
            //  var ttb = new Tbl_Pay();
            //  ttb.Amonnt = model.Amonnt;
            //  ttb.Tel = model.Tel;
            //  ttb.Email = model.Email;
            //  ttb.Name = model.Name;
            db.Add (tb);
            db.SaveChanges ();
            id = db.Tbl_Pays.OrderByDescending (a => a.Id).Take (1).SingleOrDefault ().Id;
            amount1 = Convert.ToInt32 (model.Amonnt);

            var result = await _payment.Request (new DtoRequest () {
                Mobile = "09121112222",
                    CallbackUrl = "https://localhost:5001/pay/validate",
                    Description = model.Name,
                    Email = model.Email,
                    Amount = Convert.ToInt32 (model.Amonnt),
                    MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
            }, ZarinPal.Class.Payment.Mode.sandbox);
            return Redirect ($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");
        }
        ///////////////////////////////////////////////////////////////////////////اعتبارسنجی پرداخت
        public async Task<IActionResult> Validate (string authority, string status) {
            var verification = await _payment.Verification (new DtoVerification {
                Amount = amount1,
                    MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                    Authority = authority
            }, Payment.Mode.sandbox);

            if (verification.Status == 100) {
                var x = db.Tbl_Pays.Where (a => a.Id == id).SingleOrDefault ();
                x.Status = true;
                db.Tbl_Pays.Update (x);
                db.SaveChanges ();

                msg = "s";
                return RedirectToAction ("pay");

            } else {
                var x = db.Tbl_Pays.Where (a => a.Id == id).SingleOrDefault ();
                x.Status = false;
                db.Tbl_Pays.Update (x);
                db.SaveChanges ();

                msg = "e";
                return RedirectToAction ("pay");
            }

        }

        ///////////////////////////////////////////////////////////////////////////////////Enter Informations
        public IActionResult Pay () {

            if (msg != null) {
                ViewBag.msg = msg;
                msg = null;
            }

            return View ();
        }
        ///////////////////////////////////////////////////////////////////////////////////End Enter Informations
        ////////////////////////////////////////////////////////////////////list
        public IActionResult list () {
            if (massage != null) {
                ViewBag.msg = massage;
                massage = null;

            }
            ViewBag.list = db.Tbl_Pays.OrderByDescending (a => a.Id).ToList ();
            return View ();
        }

        ///////////////////////////////////////////////////////////////////////////////////Add Informations

        // public IActionResult Add (Vm_Pay model) {
        //     var tb = new Tbl_Pay () {
        //         Name = model.Name,
        //         Email = model.Email,
        //         Amonnt = model.Amonnt,
        //         Tel = model.Tel,
        //     };
        //     //  var ttb = new Tbl_Pay();
        //     //  ttb.Amonnt = model.Amonnt;
        //     //  ttb.Tel = model.Tel;
        //     //  ttb.Email = model.Email;
        //     //  ttb.Name = model.Name;
        //     db.Add (tb);
        //     db.SaveChanges ();
        //     return RedirectToAction ("pay");
        // }

        ///////////////////////////////////////////////////////////////////////////////////End Add Informations

    }
}