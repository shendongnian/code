    public class PathToDocumentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var fileInfo = new FileInfo((string)value);
            if (fileInfo.Exists)
            {
                if (String.Compare(fileInfo.Extension, ".XPS", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return new XpsDocument(fileInfo.FullName, FileAccess.Read).GetFixedDocumentSequence();
                }
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
