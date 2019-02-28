using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewsofTampa.Models
{
    public class Brewery
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string BeerAdvocate { get; set; }
        public string Untapped { get; set; }

        public string Address { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }



        public string LogoUrl { get; set; }
    }
}
