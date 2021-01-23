    class BirthdateToAgeConverter : IValueConverter
    {
        public object Convert
            (
            object value,
            Type targetType,
            object parameter,
            string language)
        {
            var birthdate = ((DateTime) value).Date;
            var age = DateTime.Today.Year - birthdate.Year;
            if (birthdate > DateTime.Today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
        public object ConvertBack
            (
            object value,
            Type targetType,
            object parameter,
            string language)
        {
            throw new NotImplementedException();
        }
    }
