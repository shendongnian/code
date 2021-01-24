        using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using LiveCharts;
    using LiveCharts.Wpf;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    
    namespace MyProject
    {    
        public partial class GraphMaker : UserControl
        {
            // PUBLIC
            public CartesianChart MyTestChart;
            public SeriesCollection MySeriesCollection { get; set; }
            public string[] Labels { get; set; }
            public string AxisTitle { get; set; }
            public Func<double, string> YFormatter { get; set; }
            public Axis Axis1, Axis2, Axis3, Axis4, Axis5, Axis6, Axis7, Axis8, Axis9, Axis10, AxisXChart;
    
    
            public GraphMaker()
            {
                InitializeComponent();
                MySeriesCollection = new SeriesCollection();
    
                MyTestChart = new CartesianChart
                {
                    DisableAnimations = true,
                    Width = 1600,
                    Height = 700,
                    Series = MySeriesCollection
                };
    
                MyTestChart.LegendLocation = LegendLocation.Right;
    
                // *** Axis 1 ***
                Axis1 = new Axis();
                Axis1.Foreground = Brushes.DodgerBlue;
                Axis1.Position = AxisPosition.RightTop;
                YFormatter = value => value.ToString("N2");
                Axis1.LabelFormatter = YFormatter;
                MyTestChart.AxisY.Add(Axis1);
    
                // *** Axis 2 ***
                Axis2 = new Axis();
                Axis2.Foreground = Brushes.IndianRed;
                Axis2.Position = AxisPosition.RightTop;
                YFormatter = value => value.ToString("N2");
                Axis2.LabelFormatter = YFormatter;
                //MyTestChart.AxisY.Add(Axis2);
    
                // *** Axis 3 ***
                Axis3 = new Axis();
                Axis3.Foreground = Brushes.Gold;
                Axis3.Position = AxisPosition.RightTop;
                YFormatter = value => value.ToString("N2");
                Axis3.LabelFormatter = YFormatter;
                //MyTestChart.AxisY.Add(Axis3);
    
                // *** Axis 4 ***
                Axis4 = new Axis();
                Axis4.Foreground = Brushes.Gray;
                Axis4.Position = AxisPosition.RightTop;
                YFormatter = value => value.ToString("N2");
                Axis4.LabelFormatter = YFormatter;
                //MyTestChart.AxisY.Add(Axis4);
    
                // *** Axis 5 ***
                Axis5 = new Axis();
                Axis5.Foreground = Brushes.DeepSkyBlue;
                Axis5.Position = AxisPosition.RightTop;
                YFormatter = value => value.ToString("N2");
                Axis5.LabelFormatter = YFormatter;
                //MyTestChart.AxisY.Add(Axis5);
    
                // *** Axis 6 ***
                Axis6 = new Axis();
                Axis6.Foreground = Brushes.HotPink;
                Axis6.Position = AxisPosition.RightTop;
                YFormatter = value => value.ToString("N2");
                Axis6.LabelFormatter = YFormatter;
                //MyTestChart.AxisY.Add(Axis6);
    
                // *** Axis 7 ***
                Axis7 = new Axis();
                Axis7.Foreground = Brushes.Orange;
                Axis7.Position = AxisPosition.RightTop;
                YFormatter = value => value.ToString("N2");
                Axis7.LabelFormatter = YFormatter;
                //MyTestChart.AxisY.Add(Axis7);
    
                // *** Axis 8 ***
                Axis8 = new Axis();
                Axis8.Foreground = Brushes.RoyalBlue;
                Axis8.Position = AxisPosition.RightTop;
                YFormatter = value => value.ToString("N2");
                Axis8.LabelFormatter = YFormatter;
                //MyTestChart.AxisY.Add(Axis8);
    
                // *** Axis 9 ***
                Axis9 = new Axis();
                Axis9.Foreground = Brushes.Black;
                Axis9.Position = AxisPosition.RightTop;
                Axis9.LabelFormatter = YFormatter;
                //MyTestChart.AxisY.Add(Axis9);
    
                // *** Axis 10 ***
                Axis10 = new Axis();
                Axis10.Foreground = Brushes.DarkTurquoise;
                Axis10.Position = AxisPosition.RightTop;
                YFormatter = value => value.ToString("N2");
                Axis10.LabelFormatter = YFormatter;
                //MyTestChart.AxisY.Add(Axis10);
    
                AxisXChart = new Axis();
                AxisXChart.Title = AxisTitle;
                AxisXChart.Labels = Labels;
            }
    
    
            public void TakeTheChart()
            {
                var viewbox = new Viewbox();
                viewbox.Child = MyTestChart;
                viewbox.Measure(MyTestChart.RenderSize);
                viewbox.Arrange(new Rect(new Point(0, 0), MyTestChart.RenderSize));
                MyTestChart.Update(true, true); //force chart redraw
                viewbox.UpdateLayout();
    
                SaveToPng(MyTestChart, "Chart.png");
                //png file was created at the root directory.
            }
    
            public void SaveToPng(FrameworkElement visual, string fileName)
            {
                var encoder = new PngBitmapEncoder();
                EncodeVisual(visual, fileName, encoder);
            }
    
            private static void EncodeVisual(FrameworkElement visual, string fileName, BitmapEncoder encoder)
            {
                var bitmap = new RenderTargetBitmap((int)visual.ActualWidth, (int)visual.ActualHeight, 96, 96, PixelFormats.Pbgra32);
                bitmap.Render(visual);
                var frame = BitmapFrame.Create(bitmap);
                encoder.Frames.Add(frame);
                using (var stream = File.Create(fileName)) encoder.Save(stream);
            }
        }
    }
