using OpenGdansk.Models.Ztm;
using OpenGdansk.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OpenGdansk.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    Vehicle? _selectedVehicle;
    ObservableCollection<Vehicle>? _vehicles;
    public ICommand? FetchHeaderCommand { get; }
    Header? _header;
    private bool isDataFetched = false;
    RootObject? _rootObject;
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
        }
    }

    private readonly DataService dataService = new();
    public MainWindowViewModel()
    {
        FetchHeaderCommand = new RelayCommand(async () => {
            CanFetchData = false;
            Header = await dataService.GetHeaderAsync(Header.URL_HEADER);
            RootObject = await dataService.GetRootObjectAsync(Header.Description.ApiUrlData);
            Vehicles = new ObservableCollection<Vehicle>(RootObject.Vehicles);
            IsDataFetched = true;
            await Task.Delay(3000);
            IsDataFetched = false;
            CanFetchData = true;
        }, () => CanFetchData);
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
