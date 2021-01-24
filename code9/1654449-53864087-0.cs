            public static bool ChartToImage(this LiveCharts.WinForms.CartesianChart cartesianChart, LineSeries data, Axis AxisX, Axis AxisY,double Width, double Height, string fileName, string targetPath, out string locationOfImage, out Exception returnEx)
        {
            bool status = false;
            returnEx = null;
            locationPath = null;
            try
            {
                var myChart = new LiveCharts.Wpf.CartesianChart
                {
                    DisableAnimations = true,
                    Width = Width,
                    Height = Height,
                    Series = new SeriesCollection(cartesianChart.Series.Configuration)
                    {
                       new LineSeries
                       {
                           Title = data.Title,
                           LineSmoothness = data.LineSmoothness,
                           StrokeThickness = data.StrokeThickness,
                           PointGeometrySize = data.PointGeometrySize,
                           Stroke = data.Stroke,
                           Values=data.Values
                       }
                    }
                };
                myChart.AxisX.Add(new Axis { IsMerged = AxisX.IsMerged, FontSize = AxisX.FontSize, FontWeight = AxisX.FontWeight, Foreground = AxisX.Foreground, Separator = new LiveCharts.Wpf.Separator { Step = AxisX.Separator.Step, StrokeThickness = AxisX.Separator.StrokeThickness, StrokeDashArray = AxisX.Separator.StrokeDashArray, Stroke = AxisX.Separator.Stroke }, Title = AxisX.Title, MinValue = AxisX.MinValue, MaxValue = AxisX.MaxValue });
                myChart.AxisY.Add(new Axis { IsMerged = AxisY.IsMerged, FontSize = AxisY.FontSize, FontWeight = AxisY.FontWeight, Foreground = AxisY.Foreground, Separator = new LiveCharts.Wpf.Separator { Step = AxisY.Separator.Step, StrokeThickness = AxisY.Separator.StrokeThickness, StrokeDashArray = AxisY.Separator.StrokeDashArray, Stroke = AxisX.Separator.Stroke }, Title = AxisY.Title, MinValue = AxisY.MinValue, MaxValue = AxisY.MaxValue });
                var viewbox = new Viewbox();
                viewbox.Child = myChart;
                viewbox.Measure(myChart.RenderSize);
                viewbox.Arrange(new Rect(new System.Windows.Point(0, 0), myChart.RenderSize));
                myChart.Update(true, true); //force chart redraw
                viewbox.UpdateLayout();
                var encoder = new PngBitmapEncoder();
                var bitmap = new RenderTargetBitmap((int)myChart.ActualWidth, (int)myChart.ActualHeight, 96, 96, PixelFormats.Pbgra32);
                bitmap.Render(myChart);
                var frame = BitmapFrame.Create(bitmap);
                encoder.Frames.Add(frame);
                string path = Path.Combine(targetPath, fileName);
                using (var stream = File.Create(path))
                {
                    encoder.Save(stream);
                    locationPath = path;
                }
                myChart = null;
                viewbox = null;
                encoder = null;
                bitmap = null;
                frame = null;
                status = true;
            }
            catch (Exception ex)
            {
                returnEx = ex;
                status = false;
            }
            return status;
        }
