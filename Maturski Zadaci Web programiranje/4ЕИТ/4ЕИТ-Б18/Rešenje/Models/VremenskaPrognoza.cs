using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace B18_Matura.Models
{
    [XmlRoot]
    public class VremenskaPrognoza
    {
        [XmlElement("Prognoza")]
        public List<Prognoza> Prognoze { get; set; }
    }
}