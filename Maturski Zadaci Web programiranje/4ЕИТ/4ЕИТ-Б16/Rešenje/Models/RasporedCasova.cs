using System.Collections.Generic;
using System.Xml.Serialization;

namespace B16_Matura.Models
{
    [XmlRoot("RasporedCasova")]
    public class RasporedCasova
    {
        [XmlElement("Raspored")]
        public List<Raspored> Rasporedi { get; set; }
    }
}