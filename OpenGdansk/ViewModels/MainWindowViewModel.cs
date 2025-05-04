using OpenGdansk.Models.Ztm;
using OpenGdansk.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;

namespace OpenGdansk.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private const string BTN_DOWNLOAD_TEXT = "Click to download";
    private const string BTN_DOWNLOADING_TEXT = "Downloading...";
    private const string BTN_DOWNLOADED_TEXT = "Download complete!";
    private Vehicle? _selectedVehicle;
    private ObservableCollection<Vehicle>? _vehicles;
    private Header? _header;
    private RootObject? _rootObject;
    private ICommand? _fetchCommand;
    private bool _canFetchData = true;
    private string _btnDownloadText = BTN_DOWNLOAD_TEXT;
    private Brush _btnTextColor = Brushes.Black;

    public ICommand? FetchHeaderCommand
    {
        get
        {
            if (_fetchCommand == null)
            {
                _fetchCommand = new RelayCommand(async () => {
                    CanFetchData = false;
                    BtnDownloadText = BTN_DOWNLOADING_TEXT;
                    Header = await dataService.GetHeaderAsync(Header.URL_HEADER);
                    RootObject = await dataService.GetRootObjectAsync(Header.Description.ApiUrlData);
                    Vehicles = new ObservableCollection<Vehicle>(RootObject.Vehicles);
                    BtnDownloadText = BTN_DOWNLOADED_TEXT;
                    BtnTextColor = Brushes.DarkGreen;
                    await Task.Delay(3000);
                    BtnDownloadText = BTN_DOWNLOAD_TEXT;
                    BtnTextColor = Brushes.Black;
                    CanFetchData = true;
                }, () => CanFetchData);
                return _fetchCommand;
            }
            return _fetchCommand;
        }
    }

    public Brush BtnTextColor
    {
        get => _btnTextColor;
        set
        {
            _btnTextColor = value;
            OnPropertyChanged();
        }
    }

    public string BtnDownloadText
    {
        get => _btnDownloadText;
        set
        {
            _btnDownloadText = value;
            OnPropertyChanged();
        }
    }

    public bool CanFetchData
    {
        get => _canFetchData;
        set
        {
            _canFetchData = value;
            OnPropertyChanged();
        }
    }

    public Header? Header
    {
        get => _header;
        set
        {
            _header = value;
            OnPropertyChanged();
        }
    }

    public RootObject? RootObject
    {
        get => _rootObject;
        set
        {
            _rootObject = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Vehicle>? Vehicles
    {
        get => _vehicles;
        set
        {
            _vehicles = value;
            OnPropertyChanged();
        }
    }

    public Vehicle? SelectedVehicle
    {
        get => _selectedVehicle;
        set
        {
            _selectedVehicle = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(SelectedVehiclePhotos));
            OnPropertyChanged(nameof(SelectedVehicleDescriptionList));
        }
    }

    public List<string>? SelectedVehiclePhotos => SelectedVehicle?.Photos;

    public List<KeyValuePair<string, string>>? SelectedVehicleDescriptionList
    {
        get
        {
            if (SelectedVehicle == null || Header == null)
                return null;
            Dictionary<string, string> columnsToLower = Header.ColumnNames.ToDictionary(StringComparer.OrdinalIgnoreCase);
            return SelectedVehicle?.GetDescriptionList().Select(_ => new KeyValuePair<string, string>(columnsToLower[_.Key], _.Value)).ToList();
        }
    }
    private readonly DataService dataService = new();

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
