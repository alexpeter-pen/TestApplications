using B16_Matura.Models;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace B16_Matura.Controllers
{
    public class RasporedController : Controller
    {
        public ActionResult Index(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return RedirectToAction("Index", "Home");
            }

            FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            XmlReader reader = new XmlTextReader(stream);

            XmlSerializer deserializer = new XmlSerializer(typeof(RasporedCasova));
            var casovi = (RasporedCasova)deserializer.Deserialize(reader);

            return View(casovi.Rasporedi);
        }

        public ActionResult Uputstvo()
        {
            return View();
        }

    }
}
