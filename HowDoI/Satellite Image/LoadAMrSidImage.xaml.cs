using System.Windows;
using System.Windows.Controls;
using ThinkGeo.MapSuite;
using ThinkGeo.MapSuite.Layers;
using ThinkGeo.MapSuite.Shapes;
using ThinkGeo.MapSuite.Wpf;

namespace CSHowDoISamples
{
    public partial class LoadAMrSidImage : UserControl
    {
        public LoadAMrSidImage()
        {
            InitializeComponent();
        }

        private void WpfMap_Loaded(object sender, RoutedEventArgs e)
        {
            wpfMap1.MapUnit = GeographyUnit.DecimalDegree;
            wpfMap1.CurrentExtent = new RectangleShape(-118.098, 84.3, 118.098, -84.3);

            MrSidRasterLayer sidImageLayer = new MrSidRasterLayer(Samples.RootDirectory + @"Data\world.sid");
            sidImageLayer.UpperThreshold = double.MaxValue;
            sidImageLayer.LowerThreshold = 0;

            LayerOverlay staticOverlay = new LayerOverlay();
            staticOverlay.Layers.Add("SidImageLayer", sidImageLayer);
            wpfMap1.Overlays.Add(staticOverlay);

            wpfMap1.Refresh();
        }
    }
}