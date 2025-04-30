using OpenGdansk.Model.Ztm;
using OpenGdansk.Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OpenGdansk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataService _dataService;

        public MainWindow()
        {
            InitializeComponent();
            _dataService = new Services.DataService();
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
           var response = await _dataService.GetHeaderAsync(Header.URL_HEADER);
        }
    }
}