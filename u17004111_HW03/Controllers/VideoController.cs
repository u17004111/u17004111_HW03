using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using _272_hw03_final_rev2.Models;
using System.IO;

namespace _272_hw03_final_rev2.Controllers
{
    public class VideoController : Controller
    {
        //Returns the 'Video' view
        public ActionResult Video()
        {
            var vidPaths = Directory.GetFileSystemEntries(Server.MapPath("~/Media/Videos/"));

            List<FileModel> videos = new List<FileModel>();
            foreach (var vidPath in vidPaths)
            {
                videos.Add(new FileModel { FileName = Path.GetFileName(vidPath) });
            }

            return View(videos);
        }

        //FileResult that returns the video file for download.
        public FileResult Download(string fileName)
        {
            var filePath = Url.Content("~/Media/Videos/" + fileName);
            return File(filePath, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        //ActionResult that allows deletion of video files.
        public ActionResult Delete(string fileName)
        {
            string filePath = "";
            filePath = Server.MapPath(Url.Content("~/Media/Videos/" + fileName));
            try
            {
                System.IO.File.Delete(filePath);

                return RedirectToAction("Video");
            }

            catch
            {
                return RedirectToAction("Video");
            }
        }
    }
}