    class BackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush();
            if (value != null )
            {
                string strValue = value.ToString();
                
                myLinearGradientBrush.StartPoint = new System.Windows.Point(0, 0);
                myLinearGradientBrush.EndPoint = new System.Windows.Point(1, 1);
                switch (strValue)
                {
                    case "Match1":
                        myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
                        myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.Red, 0.25));
                        break;
                    case "Match2":
                        myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.Blue , 0.0));
                        myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.BlueViolet, 0.25));
                        break;
                    default:
                        myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.Green , 0.0));
                        myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.GreenYellow, 0.25));
                        break;
                }
            }
            return myLinearGradientBrush;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
