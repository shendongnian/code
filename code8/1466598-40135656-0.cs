    public class ReadersGroupsCombineConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ObservableCollection<Reader> readers = (value as Test).Readers;
            ObservableCollection<Group> groups = (value as Test).Groups;
            ObservableCollection<object> readersGroups = new ObservableCollection<object>();
            foreach (Reader reader in readers)
                readersGroups.Add(reader);
            foreach (Group group in groups)
                readersGroups.Add(group);
            return readersGroups;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
