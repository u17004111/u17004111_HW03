using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using _272_hw03_final_rev2.Models;

namespace _272_hw03_final_rev2.Controllers
{
    public class HomeController : Controller
    {
        //ActionResult handles displaying the Home view.
        public ActionResult Index()
        {
            var myModel = new FileModel();
            return View(myModel);
        }

        //ActionResult that handles displaying the About view.
        public ActionResult About()
        {
            ViewBag.Message = "My about page.";

            return View();
        }
    

        //ActionResult that handles uploading files.
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase File, string selectedRadio)
        {
            var fileFolder = "";

            switch (selectedRadio)
            {
                case "doc":
                    fileFolder = Server.MapPath("~/Media/Documents");
                    break;

                case "img":
                    fileFolder = Server.MapPath("~/Media/Images");
                    break;

                case "vid":
                    fileFolder = Server.MapPath("~/Media/Videos");
                    break;

                default:
                    fileFolder = "";
                    break;
            }

            if (File != null && File.ContentLength != 0)
            {
                string fileName = Path.GetFileName(File.FileName);
                string fullPath = Path.Combine(fileFolder, fileName);

                while (System.IO.File.Exists(fullPath))
                {
                    var newName = Path.GetFileNameWithoutExtension(fileName) + "1";
                    fileName = Path.GetFileName(newName + Path.GetExtension(File.FileName));
                    fullPath = Path.Combine(fileFolder, fileName);
                }

                File.SaveAs(fullPath);
            }

            return RedirectToAction("Index");
        }
    }
}