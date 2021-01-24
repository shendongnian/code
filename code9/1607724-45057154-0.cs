    namespace myNamespace    
    {
        /// <summary>
        /// Interaction logic for ResultPopUp.xaml
        /// </summary>
        public partial class ResultPopUp : Window
        {
            public ResultPopUp(MWArray[] Result, int rows, int columns)
            {
                InitializeComponent();
            }        
        }
    
        public class MatrixToDataViewConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                var myDataTable = new DataTable(); 
                return myDataTable.DefaultView;
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
