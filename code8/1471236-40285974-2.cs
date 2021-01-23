    namespace Yoda.Frontend.Converters
    {
      using System;
      using System.Globalization;
      using System.Windows.Data;
      using Yoda.Data.Interfaces.Enums;
      using Yoda.Frontend.Extensions;
      // Second converter would be named QuestionTypeDescriptionConverter 
      public class QuestionTypeNameConverter : IValueConverter
      {
        public object Convert(object value, Type targetType, object parameter,
                              CultureInfo culture)
        {
          // Second converter would call .ToDescription() instead
          return (value as QuestionType? ?? QuestionType.Unknown).ToName();
        }
        public object ConvertBack(object value, Type targetType, object parameter,
                                  CultureInfo culture)
        {
          return value;
        }
      }
    }
