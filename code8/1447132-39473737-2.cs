    [ValueConversion(typeof(IModel), typeof(string))]
    public class BooksConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var book = value as Book;
            if (book != null)
            {
            	return book.Name + " - " + string.Join(", ", book.Authors.Select(x => x.Name));
            }
            else
            {
            	return "";
            }
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
