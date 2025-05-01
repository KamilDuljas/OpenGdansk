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

public class Metadata
{
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("sourceDate")]
    public DateTime SourceDate { get; set; }

    [JsonPropertyName("generationDate")]
    public DateTime GenerationDate { get; set; }

    [JsonPropertyName("apiUrlHeader")]
    public required string ApiUrlHeader { get; set; }
}

public class Vehicle
{
    [JsonPropertyName("photo")]
    public required string Photo { get; set; }

    [JsonPropertyName("vehicleCode")]
    public required string VehicleCode { get; set; }

    [JsonPropertyName("carrirer")]
    public required string Carrirer { get; set; }

    [JsonPropertyName("transportationType")]
    public required string TransportationType { get; set; }

    [JsonPropertyName("vehicleCharacteristics")]
    public required string VehicleCharacteristics { get; set; }

    [JsonPropertyName("bidirectional")]
    public bool Bidirectional { get; set; }

    [JsonPropertyName("historicVehicle")]
    public bool HistoricVehicle { get; set; }

    [JsonPropertyName("length")]
    public double Length { get; set; }

    [JsonPropertyName("brand")]
    public required string Brand { get; set; }

    [JsonPropertyName("model")]
    public required string Model { get; set; }

    [JsonPropertyName("productionYear")]
    public int ProductionYear { get; set; }

    [JsonPropertyName("seats")]
    public int Seats { get; set; }

    [JsonPropertyName("standingPlaces")]
    public int StandingPlaces { get; set; }

    [JsonPropertyName("airConditioning")]
    public bool AirConditioning { get; set; }
        
    [JsonPropertyName("monitoring")]
    public bool Monitoring { get; set; }

    [JsonPropertyName("internalMonitor")]
    public bool InternalMonitor { get; set; }

    [JsonPropertyName("floorHeight")]
    public required string FloorHeight { get; set; }

    [JsonPropertyName("kneelingMechanism")]
    public bool KneelingMechanism { get; set; }

    [JsonPropertyName("wheelchairsRamp")]
    public bool WheelchairsRamp { get; set; }

    [JsonPropertyName("usb")]
    public bool Usb { get; set; }

    [JsonPropertyName("voiceAnnouncements")]
    public bool VoiceAnnouncements { get; set; }

    [JsonPropertyName("aed")]
    public bool Aed { get; set; }

    [JsonPropertyName("bikeHolders")]
    public int BikeHolders { get; set; }

    [JsonPropertyName("ticketMachine")]
    public bool TicketMachine { get; set; }

    [JsonPropertyName("patron")]
    public required string Patron { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }

    [JsonPropertyName("passengersDoors")]
    public int PassengersDoors { get; set; }

    [JsonPropertyName("driveType")]
    public string DriveType { get; set; }
}

public class RootObject
{
    [JsonPropertyName("metadata")]
    public required Metadata Metadata { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("results")]
    public required List<Vehicle> Vehicles { get; set; }

    public const string URL_PHOTO = "https://files.cloudgdansk.pl/f/otwarte-dane/ztm/baza-pojazdow/";

}
