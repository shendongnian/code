    public partial class MainWindow:Window
    {
        public MainWindow()
        {
            InitializeComponent ();
            List<MyClass> myClasses=new List<MyClass> ();
            dataGrid.ItemsSource=myClasses;
        }
    }
    public class MyClass
    {
        public double Size { get; set; }
    }
    public class SizeConverter:IValueConverter
    {
        public object Convert(object value,Type targetType,object parameter,System.Globalization.CultureInfo culture)
        {
            return System.Convert.ToString (value);
        }
        public object ConvertBack(object value,Type targetType,object parameter,System.Globalization.CultureInfo culture)
        {
            try
            {
                string size=System.Convert.ToString (value);
                string[] s=size.Split (',');
                if (s.Count ()==2)
                    return System.Convert.ToDouble (s[0]+'.'+s[1]);
                else
                    return System.Convert.ToDouble (value);
            }
            catch (Exception e)
            {
                MessageBox.Show (e.Message);
            }
            return 0;
        }
    }
