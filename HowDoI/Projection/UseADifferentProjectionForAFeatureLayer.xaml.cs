using System.Windows;
using System.Windows.Controls;
using ThinkGeo.MapSuite;
using ThinkGeo.MapSuite.Drawing;
using ThinkGeo.MapSuite.Layers;
using ThinkGeo.MapSuite.Shapes;
using ThinkGeo.MapSuite.Styles;
using ThinkGeo.MapSuite.Wpf;

namespace CSHowDoISamples
{
    public partial class UseADifferentProjectionForAFeatureLayer : UserControl
    {
        public UseADifferentProjectionForAFeatureLayer()
        {
            InitializeComponent();
        }

        private void WpfMap_Loaded(object sender, RoutedEventArgs e)
        {
            wpfMap1.MapUnit = GeographyUnit.Meter;

            // If want to know more srids, please refer Projections.rtf in Documentation folder.
            Proj4Projection proj4Projection = new Proj4Projection();
            proj4Projection.InternalProjectionParametersString = Proj4Projection.GetEpsgParametersString(4326);
            proj4Projection.ExternalProjectionParametersString = Proj4Projection.GetEpsgParametersString(2163);

            ShapeFileFeatureLayer worldLayer = new ShapeFileFeatureLayer(Samples.RootDirectory + @"Data\Countries02.shp");
            worldLayer.ZoomLevelSet.ZoomLevel01.DefaultAreaStyle = AreaStyles.Country1;
            worldLayer.ZoomLevelSet.ZoomLevel01.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;
            worldLayer.FeatureSource.Projection = proj4Projection;

            worldLayer.Open();
            wpfMap1.CurrentExtent = worldLayer.GetBoundingBox();
            worldLayer.Close();

            LayerOverlay staticOverlay = new LayerOverlay();
            staticOverlay.TileType = TileType.SingleTile;
            staticOverlay.Layers.Add(new BackgroundLayer(new GeoSolidBrush(GeoColor.GeographicColors.ShallowOcean)));
            staticOverlay.Layers.Add("WorldLayer", worldLayer);
            wpfMap1.Overlays.Add(staticOverlay);

            wpfMap1.Refresh();
        }
    }
}