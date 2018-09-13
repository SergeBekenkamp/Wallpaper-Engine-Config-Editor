using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpEngineConfigEditor;

namespace WpEngineConfigEditor
{
    [CamelCasePropertyNamesContractResolver]
    public class WpConfig
    {
        public GeneralConfig General { get; set; }

        public string Version { get; set; }

        public WallpaperProperties[] Wallpaperproperties { get; set; }
    }

    public class GeneralConfig
    {
        public object Browser { get; set; }
        public object Editor { get; set; }
        public string[] Localfiles { get; set; }
        public PlaylistConfig[] Playlists { get; set; }
        public object User { get; set; }
        public object Wallpaperconfig { get; set; }
        public object Wallpaperconfigrecent { get; set; }
    
    }

    public class PlaylistConfig
    {
        public string[] Items { get; set; }
        public string Name { get; set; }
        public object Settings { get; set; }
    }

    public class WallpaperProperties
    {
        public string File { get; set; }
        public Dictionary<string, WallpaperOptions> monitors { get; set; }
    }
}
