    class IntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // Retrieve the format string and use it to format the value.
            int votenumber, currentone;
            if (parameter != null)
            {
                votenumber = System.Convert.ToInt32(value);
                currentone = System.Convert.ToInt32(parameter);
    
                if (votenumber == currentone)
                    return true;
            }    
            return false;
        }
    
        // No need to implement converting back on a one-way binding 
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
