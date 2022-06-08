using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using _272_hw03_final_rev2.Models;
using System.IO;

namespace _272_hw03_final_rev2.Controllers
{
    public class ImageController : Controller
    {
        //ActionResult that returns the 'Image' view.
        public ActionResult Image()
        {
            var imgPaths = Directory.GetFileSystemEntries(Server.MapPath("~/Media/Images/"));

            List<FileModel> images = new List<FileModel>();
            foreach (var imgPath in imgPaths)
            {
                images.Add(new FileModel { FileName = Path.GetFileName(imgPath) });
            }

            return View(images);
        }

        //FileResult that returns the image file for download.
        public FileResult Download(string fileName)
        {
            var filePath = Url.Content("~/Media/Images/" + fileName);
            return File(filePath, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        //ActionResult that allows deletion of image files.
        public ActionResult Delete(string fileName)
        {
            string filePath = "";
            filePath = Server.MapPath(Url.Content("~/Media/Images/" + fileName));
            try
            {
                System.IO.File.Delete(filePath);

                return RedirectToAction("Image");
            }
            catch
            {
                return RedirectToAction("Image");
            }
        }
    }
}