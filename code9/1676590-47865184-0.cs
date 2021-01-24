    using System;
    
    namespace WpfApp1
    {
        using System.Windows;
        using System.Windows.Media;
        using System.Windows.Threading;
    
        public sealed class MainTimer : FrameworkElement
        {
            private DispatcherTimer Timer = new DispatcherTimer();
    
            public MainTimer()
            {
                // what you are looking for is InvalidateVisual
                this.Timer.Tick += (sender, args) => this.InvalidateVisual();
                // changed your timespan to a more appropriate value
                this.Timer.Interval = TimeSpan.FromSeconds(1);
                this.Timer.Start();
            }
    
            protected override void OnRender(DrawingContext drawingContext)
            {
                string mode = "12";
    
                System.Diagnostics.Trace.WriteLine("Rendering");
    
                if (Application.Current.MainWindow != null)
                {
                    if (mode == "24")
                    {
                        drawingContext.DrawText(new FormattedText(DateTime.Now.ToLongTimeString(), System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Microsoft PhagsPa"), 50, new SolidColorBrush(Color.FromArgb(50, 235, 255, 255))), new Point(0, -15));
                    }
                    else
                    {
                        string st = "";
    
                        if (DateTime.Now.Hour > 12)
                        {
                            st = ((DateTime.Now.Hour - 12).ToString("00") + " : " + DateTime.Now.Minute.ToString("00") + " : " + DateTime.Now.Second.ToString("00")) + " pm";
                        }
                        else
                        {
                            st = ((DateTime.Now.Hour).ToString("00") + " : " + DateTime.Now.Minute.ToString("00") + " : " + DateTime.Now.Second.ToString("00")) + " am";
                        }
    
    
                        drawingContext.DrawText(new FormattedText(st, System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Microsoft PhagsPa"), 40, new SolidColorBrush(Color.FromArgb(50, 200, 255, 255))), new Point(0, -12));
                    }
                }
            }
        }
    }
