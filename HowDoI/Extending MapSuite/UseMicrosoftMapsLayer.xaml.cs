using System.Windows;
using System.Windows.Controls;
using ThinkGeo.MapSuite;
using ThinkGeo.MapSuite.Layers;
using ThinkGeo.MapSuite.Shapes;
using ThinkGeo.MapSuite.Wpf;

namespace CSHowDoISamples
{
    public partial class UseMicrosoftMapsLayer : UserControl
    {
        public UseMicrosoftMapsLayer()
        {
            InitializeComponent();
        }

        private void WpfMap_Loaded(object sender, RoutedEventArgs e)
        {
            // Please set your own information about those parameters below.
            string applicationID = "Your ApplicationID";
            string cacheDirectory = @"c:\temp\";
            BingMapsLayer worldLayer = new BingMapsLayer(applicationID, ThinkGeo.MapSuite.Layers.BingMapsMapType.Road, cacheDirectory);

            wpfMap1.MapUnit = GeographyUnit.Meter;
            wpfMap1.CurrentExtent = new RectangleShape(-10000000, 10000000, 10000000, -10000000);
            LayerOverlay worldOverlay = new LayerOverlay();
            worldOverlay.Layers.Add("WorldLayer", worldLayer);

            wpfMap1.Overlays.Add("WorldOverlay", worldOverlay);
            wpfMap1.Refresh();
        }
    }
}