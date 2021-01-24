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
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            int  currentone;
            if (parameter != null)
            {
                currentone = System.Convert.ToInt32(parameter);
                if (currentone==0)
                {
                    return currentone;
                }
                else
                {
                   return currentone;   
                }
            }
            return 0;
        }
    }
