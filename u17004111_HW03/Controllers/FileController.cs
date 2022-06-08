using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using _272_hw03_final_rev2.Models;
using System.IO;

namespace _272_hw03_final_rev2.Controllers
{
    public class FileController : Controller
    {
        //ActionResult for each view returns a list of the relevant files via the model.
        public ActionResult File()
        {
            var docPaths = Directory.GetFileSystemEntries(Server.MapPath("~/Media/Documents/"));

            List<FileModel> documents = new List<FileModel>();
            foreach (var docPath in docPaths)
            {
                documents.Add(new FileModel { FileName = Path.GetFileName(docPath) });
            }

            return View(documents);
        }

        public FileResult Download(string fileName)
        {
            var filePath = Url.Content("~/Media/Documents/" + fileName);
            return File(filePath, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public ActionResult Delete(string fileName)
        {
            string filePath = "";
            filePath = Server.MapPath(Url.Content("~/Media/Documents/" + fileName));
            try
            {
                System.IO.File.Delete(filePath);

                return RedirectToAction("File");
            }

            catch
            {
                return RedirectToAction("File");
            }
        }
    }
}
