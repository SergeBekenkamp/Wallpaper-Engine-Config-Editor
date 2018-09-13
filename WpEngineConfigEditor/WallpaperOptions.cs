using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpEngineConfigEditor
{
    public enum WallpaperAlignment
    {
        Cover = 0,
        Center = 1,
        Stretch = 2,
    }

    public class WallpaperOptions
    {

        public WallpaperAlignment Alignment { get; set; } = WallpaperAlignment.Center;
        public int Alignmentposition { get; set; } = 50;
        public int Rate { get; set; } = 100;
    }
}
