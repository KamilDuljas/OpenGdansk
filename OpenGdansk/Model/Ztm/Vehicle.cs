using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace OpenGdansk.Model.Ztm
{
    public class Header
    {
        public const string URL_HEADER = "https://files.cloudgdansk.pl/d/otwarte-dane/ztm/baza-pojazdow.header.json?v=2";

        [JsonPropertyName("description")]
        public Description Description { get; set; }

        [JsonPropertyName("columnNames")]
        public Dictionary<string, string> ColumnNames { get; set; }

        [JsonPropertyName("fieldTypes")]
        public Dictionary<string, string> FieldTypes { get; set; }

    }
    public class Description
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("province")]
        public string Province { get; set; }

        [JsonPropertyName("sourceDate")]
        public DateTime SourceDate { get; set; }

        [JsonPropertyName("generationDate")]
        public DateTime GenerationDate { get; set; }

        [JsonPropertyName("owner")]
        public string Owner { get; set; }

        [JsonPropertyName("apiUrlData")]
        public string ApiUrlData { get; set; }

        [JsonPropertyName("licence")]
        public string Licence { get; set; }
    }
        //public class Description
        //{
        //    [JsonPropertyName("version")]
        //    public string Version { get; set; }
        //    [JsonPropertyName("title")]
        //    public string Title { get; set; }
        //    [JsonPropertyName("sourceDate")]
        //    public DateTime SourceDate { get; set; }
        //    [JsonPropertyName("generationDate")]
        //    public DateTime GenerationDate { get; set; }
        //    [JsonPropertyName("apiUrlData")]
        //    public string ApiUrlData { get; set; }
        //}

        //public Description description { get; set; }

    public class Vehicle
    {
        public const string URL_PHOTO = "https://files.cloudgdansk.pl/f/otwarte-dane/ztm/baza-pojazdow/";
    }

}
