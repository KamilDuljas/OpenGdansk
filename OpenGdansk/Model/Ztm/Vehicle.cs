using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace OpenGdansk.Model.Ztm
{
    public class Header
    {
        public const string URL_HEADER = "https://files.cloudgdansk.pl/d/otwarte-dane/ztm/baza-pojazdow.header.json?v=2";

        public string Version { get; set; }
        public string Title { get; set; }
        public DateTime SourceDate {  get; set; }
        public DateTime GenerationDate {  get; set; }
        public string ApiUrlData { get; set; }

    }

    public class Vehicle
    {
        public const string URL_PHOTO = "https://files.cloudgdansk.pl/f/otwarte-dane/ztm/baza-pojazdow/";
    }

}
