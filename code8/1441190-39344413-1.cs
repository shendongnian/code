    public sealed partial class BarChat : Page
    {
        private Random _random = new Random();
        private LinearAxis linearaxis;
        private CategoryAxis categoryaxis;
        private double linearaximaximum;
        private double linearaximinimum;
        private Line newline;
        public BarChat()
        {
            this.InitializeComponent();
            Window.Current.SizeChanged += Current_SizeChanged; ;
            var items1 = new List<NameValueItem>();
            for (int i = 0; i < 3; i++)
            {
                items1.Add(new NameValueItem { Name = "Name" + i, Value = _random.Next(1, 100) });
            }
            this.RunIfSelected(this.BarChart, () => ((BarSeries)this.BarChart.Series[0]).ItemsSource = items1);
        }
        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            if (rootgrid.Children.Contains(newline))
            {
                clearline();
                if (txtnumber.Text != null)
                {
                    var insertvalue = Convert.ToDouble(txtnumber.Text);
                    positionline(insertvalue);
                }
            }
        }
        public void barchartinihital()
        {
            var Actualaxes = BarChart.ActualAxes;
            linearaxis = Actualaxes[1] as LinearAxis;
            categoryaxis = Actualaxes[0] as CategoryAxis;
            linearaximaximum = Convert.ToDouble(linearaxis.ActualMaximum);
            linearaximinimum = Convert.ToDouble(linearaxis.ActualMinimum);
        }
        private void RunIfSelected(UIElement element, Action action)
        {
            action.Invoke();
        }
        private async void getaxi_Click(object sender, RoutedEventArgs e)
        {
            clearline();
            barchartinihital();          
            if (txtnumber.Text != null)
            {                
                 double insertvalue = Convert.ToDouble(txtnumber.Text);  
                if (insertvalue > linearaximaximum || insertvalue < linearaximinimum)
                {
                    await new Windows.UI.Popups.MessageDialog("Please input a value in chart arrange").ShowAsync();
                }
                else
                {
                    positionline(insertvalue);
                }
            }
        }
        public void positionline(double insertvalue)
        {
            var interval = linearaxis.ActualInterval;
            double perinterval = Convert.ToDouble(linearaxis.ActualWidth / (linearaximaximum - linearaximinimum));
            var lineX = perinterval * (insertvalue - linearaximinimum);
            var lineheight = categoryaxis.ActualHeight;
            var ttv = bar.TransformToVisual(Window.Current.Content);
            Point screenCoords = ttv.TransformPoint(new Point(0, 0));
            var chartx = screenCoords.X;
            var charty = screenCoords.Y;
            newline = new Line();
            newline.X1 = Convert.ToDouble(lineX) + chartx;
            newline.X2 = Convert.ToDouble(lineX) + chartx;
            newline.Y1 = charty;
            newline.Y2 = charty + lineheight;
            newline.Stroke = new SolidColorBrush(Colors.Red);
            newline.StrokeThickness = 2;
            rootgrid.Children.Add(newline);
        }
        public void clearline()
        {
            if (rootgrid.Children.Contains(newline))
            {
                {
                    rootgrid.Children.Remove(newline);
                }
            }
        }
    }
