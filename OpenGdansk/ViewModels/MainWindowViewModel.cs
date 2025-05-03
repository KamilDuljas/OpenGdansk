using OpenGdansk.Models.Ztm;
using OpenGdansk.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace OpenGdansk.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private Vehicle? _selectedVehicle;
    private ObservableCollection<Vehicle>? _vehicles;
    private Header? _header;
    private bool isDataFetched = false;
    private RootObject? _rootObject;
    private ICommand? _fetchCommand;
    public ICommand? FetchHeaderCommand
    {
        get
        {
            if (_fetchCommand == null)
            {
                _fetchCommand = new RelayCommand(async () => {
                    CanFetchData = false;
                    Header = await dataService.GetHeaderAsync(Header.URL_HEADER);
                    RootObject = await dataService.GetRootObjectAsync(Header.Description.ApiUrlData);
                    Vehicles = new ObservableCollection<Vehicle>(RootObject.Vehicles);
                    IsDataFetched = true;
                    await Task.Delay(3000);
                    IsDataFetched = false;
                    CanFetchData = true;
                }, () => CanFetchData);
                return _fetchCommand;
            }
            return _fetchCommand;
        }
    }

    public bool IsDataFetched
    {
        get => isDataFetched;
        set
        {
            isDataFetched = value;
            OnPropertyChanged();
        }
    }

    private bool canFetchData = true;
    public bool CanFetchData
    {
        get => canFetchData;
        set
        {
            canFetchData = value;
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
            return SelectedVehicle?.DescriptionList.Select(_ => new KeyValuePair<string, string>(columnsToLower[_.Key], _.Value)).ToList();
        }
    }
    private readonly DataService dataService = new();

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
