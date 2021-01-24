    public class ImgToSrcConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Image image = values[0] as Image;
            if (image != null)
            {
                MemoryStream ms = new MemoryStream();
                image.Save(ms, image.RawFormat);
                ms.Seek(0, SeekOrigin.Begin);
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = ms;
                bi.EndInit();
                ViewModel vm = values[1] as ViewModel;
                bi.DownloadCompleted += (s, e) => 
                {
                    vm.Method();
                };
                return bi;
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
