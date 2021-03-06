using u2145249_HW03.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace u2145249_HW03.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {

            string[] filePaths = Directory.GetFiles(HttpContext.Server.MapPath("~/Media/Documents/"));
            List<FileModel> fileList = new List<FileModel>();
            foreach (string filePath in filePaths)
            {
                FileModel filemodel = new FileModel();
                filemodel.FileName = Path.GetFileName(filePath);
                fileList.Add(filemodel);
            }


            return View(fileList);
        }

        public ActionResult DownloadFile(string FileName)
        {
            
            string path = Server.MapPath("~/Media/Documents/") + FileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", FileName);

        }

        public ActionResult DeleteFile(string FileName)
        {

            string fullPath = Request.MapPath("~/Media/Documents/" + FileName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            return RedirectToAction("Index");

        } 
    }
}
