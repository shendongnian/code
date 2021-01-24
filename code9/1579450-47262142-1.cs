    /// <summary>
        /// Author: Suman Kumar
        /// It will increase or decrease width and height of any conrol
        /// Parameter should be like: "+,12"
        /// + is indicating increase and 12 is indicating length will be increased by 12 px
        /// </summary>
        public class WidthHeightExtender: IValueConverter
        {
            #region IValueConverter Members
    
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                try
                {
                    string []str = (parameter as string).Split(',');
                    if (str[0].Equals("+"))
                        return System.Convert.ToDouble(value) + System.Convert.ToDouble(str[1]);
                    else if (str[0].Equals("-"))
                        return System.Convert.ToDouble(value) - System.Convert.ToDouble(str[1]);
                    else
                        return System.Convert.ToDouble(value);
                }
                catch(Exception ex)
                {
                    return System.Convert.ToDouble(value);
                }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    
            #endregion
    
        }
