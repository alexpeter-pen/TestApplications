using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B18_Matura.Models
{
    public class Prognoza
	{
		public string Mesto { get; set; }
		public string NazivMesta { get; set; }
		public string MinTemperatura { get; set; }
		public string MaxTemperatura { get; set; }
		public string Vreme { get; set; }
	}
}