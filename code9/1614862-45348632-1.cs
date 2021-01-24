    Size overSize = new Size(2000, 2000);    // Something oversized.
    chartControl.Measure(overSize);
    chartControl.Arrange(new Rect(chartControl.DesiredSize));
    chartControl.UpdateLayout();
    // Take a screenshot of the chart control
    BitmapSource bitmapSource = ScreenshotHelper.CreateScreenshot(chartControl, new Int32Rect(0, 0, (int)chartControl.ActualWidth, (int)chartControl.ActualHeight));
            
