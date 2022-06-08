using u2145249_HW03.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace u2145249_HW03.Controllers
{
    public class HomeController : Controller
    {

        // Returns the home page
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string FileType, HttpPostedFileBase Files)
        {                     
            
               
            // check if a file has been uploaded
            if (Files != null)
            {
                string extension = Path.GetExtension(Files.FileName);
                
                if (FileType == "Document")
                {
                    
                    Files.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Documents"), Path.GetFileName(Files.FileName)));
                    ViewBag.Message = "File uploaded successfully";
                }
                else if( FileType == "Image")
                {
                    
                    Files.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Images"), Path.GetFileName(Files.FileName)));
                    ViewBag.Message = "Image uploaded successfully";
                } 
                else if( FileType == "Video")
                {
                    
                    Files.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Videos"), Path.GetFileName(Files.FileName)));
                    ViewBag.Message = "Video uploaded successfully";
                }
            }
            else
            {
                ViewBag.Message = "Plese Select a file";
             
            }
            
            return View();
        }

        public ActionResult About()
        {
            return View();
        }



    }
}