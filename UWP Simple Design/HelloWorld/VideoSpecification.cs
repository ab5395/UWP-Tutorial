using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class VideoSpecification
    {
        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }
        public int SlideShowTime { get; set; }
        public int ConvertVideoHeight { get; set; }
        public int ConvertVideoWidth { get; set; }
        public string ConvertVideoFormat { get; set; }
        public string WaterMarkText { get; set; }
        public string WaterMarkImage { get; set; }
        public string WaterMarkPosition { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public int WaterMarkTextHeight { get; set; }
        public int WaterMarkTextWidth { get; set; }
    }
}
