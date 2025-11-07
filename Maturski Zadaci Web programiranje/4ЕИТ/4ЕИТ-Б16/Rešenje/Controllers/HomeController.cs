using System.IO;
using System.Web;
using System.Web.Mvc;

namespace B16_Matura.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            // Handle file upload logic here
            if (file != null && file.ContentLength > 0)
            {
                // Save the file to the server or perform any other necessary operations
                var fileName = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/App_Data/Uploads"), fileName);
                file.SaveAs(path);

                return RedirectToAction("Index", "Raspored", new { filePath = path });
            }
            else
            {
                // Display error message
                ViewBag.Message = "Selektujte XML file za učitavanje.";
            }

            return View("Index");
        }
    }
}