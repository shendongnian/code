    public class SyncConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
          if(value != null){
            bool? syncState = value as bool?;
            if (syncState != null) { 
                if (syncState.Value) return ConvertToImageSource("ic_success");
                else return ConvertToImageSource("ic_error");
            }
           }
          return ConvertToImageSource("ic_idle");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        private ImageSource ConvertToImageSource(string fileName)
        {
             return Device.OnPlatform(
                  iOS: ImageSource.FromFile($"Images/{fileName}"),
                  Android:  ImageSource.FromFile(fileName),
                  WinPhone: ImageSource.FromFile($"Images/{fileName}"));
        }
    }
