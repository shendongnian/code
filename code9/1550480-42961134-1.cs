    public class TypeToImageConverter : IValueConverter {
        static readonly HashSet<string> _pdfExtensions = new HashSet<string>(new[] {"pdf"});
        static readonly HashSet<string> _excelExtensions = new HashSet<string>(new[] { "xlr", "xlsx", "xlsm" });
        // and so on
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var ext = value as string;            
            string relativePath = null;
            if (ext != null) {
                ext = ext.ToLowerInvariant();
                if (_pdfExtensions.Contains(ext))
                    relativePath = "/Images/pdf.png"; 
                else if (_excelExtensions.Contains(ext))
                    relativePath = "/Images/excel.png";
                // and so on
            }
            if (relativePath != null) {
                var bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.UriSource = new Uri(relativePath, UriKind.Relative);
                bmp.EndInit();
                return bmp;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
