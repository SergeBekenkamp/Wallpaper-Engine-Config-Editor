using System;
using System.Collections.Generic;
using System.IO;
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
using Newtonsoft.Json.Serialization;

namespace WpEngineConfigEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string selectedFile = null;
        private string fileContent = null;

        private WallpaperOptions defaultOptions = new WallpaperOptions();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "config";
            dialog.DefaultExt = "json";
            dialog.Filter = "Config documents (.Json)|*.json";
            dialog.InitialDirectory = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\wallpaper_engine";

            Nullable<bool> result = dialog.ShowDialog();
            if (result == true)
            {
                selectedFile = dialog.FileName;
                selectedFileNameLabel.Content = $"Selected file: {dialog.FileName}";
                fileContent = File.ReadAllText(dialog.FileName);

                var jsonContent = JsonConvert.DeserializeObject<Dictionary<string, WpConfig>>(fileContent);
                var allFiles = jsonContent.SelectMany(c => c.Value.General.Playlists).SelectMany(c => c.Items).ToList();
                var allMonitors = jsonContent.SelectMany(c => c.Value.Wallpaperproperties)
                    .SelectMany(c => c.monitors.Keys).Distinct().ToList();

                foreach (var x in jsonContent.Values)
                {
                    x.Wallpaperproperties = allFiles.Select(b => new WallpaperProperties
                    {
                        File = b,
                        monitors = allMonitors.Select(v => (v, new WallpaperOptions()))
                            .ToDictionary(v => v.Item1, v => v.Item2),
                    }).ToArray();
                }
                File.WriteAllText(selectedFile, JsonConvert.SerializeObject(jsonContent, Formatting.Indented, new JsonSerializerSettings
                {

                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    
                }));
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}