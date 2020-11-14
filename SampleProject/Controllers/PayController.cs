using System.Security.Cryptography;
     using System.Threading.Tasks;
     using DataLayer.Context;
     using DataLayer.Entities;
     using Dto.Payment;
     using Microsoft.AspNetCore.Mvc;
     using ViewModel.Entities;
     using ZarinPal.Class;
     using Microsoft.AspNetCore.Hosting;


     namespace Sample.Controllers {
         ////////////////////////////////////////////////////////////////////database

         public class PayController : Controller {

             private readonly Context_db db;
             private readonly IWebHostEnvironment env;
      
             private readonly Payment _payment;
             private readonly Authority _authority;
             private readonly Transactions _transactions;
             public static string msg;
             public PayController (Context_db _db,IWebHostEnvironment _env) {
                 var expose = new Expose ();
                 _payment = expose.CreatePayment ();
                 _authority = expose.CreateAuthority ();
                 _transactions = expose.CreateTransactions ();

                  db=_db;
                 env=_env;
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

             public async Task<IActionResult> Request () {
                 var result = await _payment.Request (new DtoRequest () {
                     Mobile = "09121112222",
                         CallbackUrl = "https://localhost:5001/pay/validate",
                         Description = "توضیحات",
                         Email = "farazmaan@outlook.com",
                         Amount = 1000000,
                         MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
                 }, ZarinPal.Class.Payment.Mode.sandbox);
                 return Redirect ($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");
             }

             ///////////////////////////////////////////////////////////////////////////اعتبارسنجی پرداخت
             public async Task<IActionResult> Validate (string authority, string status) {
                 var verification = await _payment.Verification (new DtoVerification {
                     Amount = 1000000,
                         MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                         Authority = authority
                 }, Payment.Mode.sandbox);

                 if (verification.Status == 100) {
                     msg = "s";
                     return RedirectToAction ("Index");

                 } else {
                     msg = "e";
                     return RedirectToAction ("Index");
                 }

             }

             ///////////////////////////////////////////////////////////////////////////////////Enter Informations
             public IActionResult Pay () {

                 return View ();

             }
             ///////////////////////////////////////////////////////////////////////////////////End Enter Informations

             ///////////////////////////////////////////////////////////////////////////////////Add Informations

             public IActionResult Add (Vm_Pay model) {
                 var tb = new Tbl_Pay(){
                     Name=model.Name,
                     Email=model.Email,
                     Amonnt=model.Amonnt,
                     Tel=model.Tel,
                 };
                //  var ttb = new Tbl_Pay();
                //  ttb.Amonnt = model.Amonnt;
                //  ttb.Tel = model.Tel;
                //  ttb.Email = model.Email;
                //  ttb.Name = model.Name;
                db.Add(tb);
                db.SaveChanges();
                 return RedirectToAction ("pay");
             }

             ///////////////////////////////////////////////////////////////////////////////////End Add Informations

         }
     }