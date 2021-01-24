    public class CountStudentCoursePointsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var studentModel = (StudentListModel)values[0];
            var courseId = (Guid)values[1];
            return studentModel.CountPoints(courseId); 
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            //  Can't convert back, don't try. 
            throw new NotImplementedException();
        }
    }
