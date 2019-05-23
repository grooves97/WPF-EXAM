using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using EarthquakeAPI.Models;
using EarthquakeAPI.Services.Abstract;
using EarthquakeAPI.Services;

namespace EarthquakeAPI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            FillList();
        }

        private void FillList()
        {
            ILogger logger = new FileLogger();
            IDownloader downloader = new Downloader(logger);

                string json = downloader.DownloadRawJsonData($"https://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&limit={dataTextBox.Text}");
                var data = JsonConvert.DeserializeObject<FeatureCollection>(json);

                List<Property> features = new List<Property>();

                foreach (var feature in data.Features)
                {
                    features.Add(feature.properties);
                }

                apiDataGrid.ItemsSource = features;

            
        }
    }
}
