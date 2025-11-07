using B18_Matura.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace B18_Matura.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            VremenskaPrognoza prognoze = ExtractPrognoze();

            return View(prognoze.Prognoze);
        }

        private VremenskaPrognoza ExtractPrognoze()
        {
            string path = Path.Combine(Server.MapPath("~/App_Data"), "VremenskaPrognoza.xml");

            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            XmlReader reader = new XmlTextReader(stream);

            XmlSerializer deserializer = new XmlSerializer(typeof(VremenskaPrognoza));
            var prognoze = (VremenskaPrognoza)deserializer.Deserialize(reader);
            return prognoze;
        }

        public ActionResult Prognoza(string nazivMesta)
        {
            var prognoze = ExtractPrognoze();
            var gradovi = prognoze.Prognoze.Select(sel => sel.NazivMesta).Distinct();

            if (string.IsNullOrEmpty(nazivMesta))
                nazivMesta = gradovi.First();

            ViewBag.Cities = new SelectList(gradovi, nazivMesta);

            return View(prognoze.Prognoze.FirstOrDefault(c => c.NazivMesta == nazivMesta));
        }

        public ActionResult Uputstvo()
        {
            return View();
        }
    }
}