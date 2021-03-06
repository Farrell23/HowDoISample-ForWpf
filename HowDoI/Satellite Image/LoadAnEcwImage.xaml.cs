﻿using System.Windows;
using System.Windows.Controls;
using ThinkGeo.MapSuite;
using ThinkGeo.MapSuite.Layers;
using ThinkGeo.MapSuite.Shapes;
using ThinkGeo.MapSuite.Wpf;

namespace CSHowDoISamples
{
    public partial class LoadAnEcwImage : UserControl
    {
        public LoadAnEcwImage()
        {
            InitializeComponent();
        }

        private void WpfMap_Loaded(object sender, RoutedEventArgs e)
        {
            wpfMap1.MapUnit = GeographyUnit.DecimalDegree;
            wpfMap1.CurrentExtent = new RectangleShape(-118.098, 84.3, 118.098, -84.3);

            EcwRasterLayer ecwImageLayer = new EcwRasterLayer(Samples.RootDirectory + @"Data\World.ecw");
            ecwImageLayer.UpperThreshold = double.MaxValue;
            ecwImageLayer.LowerThreshold = 0;

            LayerOverlay staticOverlay = new LayerOverlay();
            staticOverlay.Layers.Add("EcwImageLayer", ecwImageLayer);
            wpfMap1.Overlays.Add(staticOverlay);

            wpfMap1.Refresh();
        }
    }
}