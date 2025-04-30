using System.Text.Json.Serialization;

namespace OpenGdansk.Models.Ztm;

public class Header
{
    public const string URL_HEADER = "https://files.cloudgdansk.pl/d/otwarte-dane/ztm/baza-pojazdow.header.json?v=2";

    [JsonPropertyName("description")]
    public required Description Description { get; set; }

    [JsonPropertyName("columnNames")]
    public required Dictionary<string, string> ColumnNames { get; set; }

    [JsonPropertyName("fieldTypes")]
    public required Dictionary<string, string> FieldTypes { get; set; }

}

public class Description
{
    [JsonPropertyName("version")]
    public required string Version { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("language")]
    public required string Language { get; set; }

    [JsonPropertyName("country")]
    public required string Country { get; set; }

    [JsonPropertyName("city")]
    public required string City { get; set; }

    [JsonPropertyName("province")]
    public required string Province { get; set; }

    [JsonPropertyName("sourceDate")]
    public required DateTime SourceDate { get; set; }

    [JsonPropertyName("generationDate")]
    public required DateTime GenerationDate { get; set; }

    [JsonPropertyName("owner")]
    public required string Owner { get; set; }

    [JsonPropertyName("apiUrlData")]
    public required string ApiUrlData { get; set; }

    [JsonPropertyName("licence")]
    public required string Licence { get; set; }
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
