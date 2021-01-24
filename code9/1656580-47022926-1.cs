    public class ListOfListsFrom2DArray : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var values = value as string[,];
            //  https://stackoverflow.com/a/37458182/424129
            var result = values.Cast<string>()
                // Use overloaded 'Select' and calculate row index.
                .Select((x, i) => new { x, index = i / values.GetLength(1) })
                // Group on Row index
                .GroupBy(x => x.index)
                // Create List for each group.  
                .Select(x => x.Select(s => s.x).ToList())
                .ToList();
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
