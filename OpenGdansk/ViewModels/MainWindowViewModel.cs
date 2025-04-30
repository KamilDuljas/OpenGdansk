using OpenGdansk.Models.Ztm;
using OpenGdansk.Services;
using System;
using System.Collections.Generic;
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
    public ICommand? FetchHeaderCommand { get; }
    Header? _header;
    private bool isDataFetched = false;

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

    private readonly DataService dataService = new();
    public MainWindowViewModel()
    {
        FetchHeaderCommand = new RelayCommand(async () => {
            CanFetchData = false;
            Header = await dataService.GetHeaderAsync(Header.URL_HEADER);
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
