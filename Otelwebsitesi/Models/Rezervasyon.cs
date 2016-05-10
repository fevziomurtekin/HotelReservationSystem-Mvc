using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Otelwebsitesi.Models
{
    public class Rezervasyon
    {
        public DateTime giristarihi { get; set; }
        public DateTime cikistarihi{ get; set; }
        public int kalacakyetiskin { get; set; }
        public int odaKat { get; set; }
        public int odaÜcreti { get; set; }

       public string odaTürü { get; set; }
      public string kategoriName { get; set; }
    }

    }
