    public class ResultTypeIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Result.ResultType)
            {
                return GetIconPath((Result.ResultType)value);
            }
            return "Images/glyphicons-195-question-sign.png";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        public static string GetIconPath(Result.ResultType rt)
        {
            switch (rt)
            {
                case Result.ResultType.Bad:
                    return "pack://application:,,,/someassembly;component/Images/badresult.png";
                case Result.ResultType.Good:
                    return "pack://application:,,,/someassembly.WPF;component/Images/goodresult.png";
                case Result.ResultType.Suspect:
                    return "pack://application:,,,/someassembly.WPF;component/Images/suspectresult.png";
                case Result.ResultType.Unknown:
                    return "pack://application:,,,/someassembly.WPF;component/Images/unknownresult.png";
                default:
                    return "pack://application:,,,/PetroUtilitiesUI.WPF;component/Images/glyphicons-195-question-sign.png";
            }
        }
    }
