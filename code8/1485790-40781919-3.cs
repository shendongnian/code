    public class IndexToItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Debug.WriteLine("CONVERT");
            return Int32.Parse(value.ToString());
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var val = value.ToString();
            var task = Task.Run(async () =>
            {
                await Task.Delay(1000);
                return val;
            });
            return task.Result;
        }
    }
