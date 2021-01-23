     public partial class MainWindow : Window
        {
            //The window is just so we have something to set a VM on if you DataContext is Self you can add the ViewModel code to the UI element (But you really should use ViewModels)
            public MainWindow()
            {
                InitializeComponent();
    
                DataContext = new VM();
            }
    
            
        }
    
        public class VM:INotifyPropertyChanged 
        {
            private string selectionItem = IsFixedValueConverter.IS_FIXED;
            public string SelectionItem 
            {
                get { return selectionItem; }
                set
                {
                    selectionItem = value;
                    if (PropertyChanged != null)//If you are using c# 6 use nameof(SelectionItem) rather than "SelectionItem"
                        PropertyChanged(this, new PropertyChangedEventArgs("SelectionItem"));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    
        public class IsFixedValueConverter : IValueConverter 
        {
            public const string IS_FIXED = "Fixed";
    
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return value!= null?value.ToString() == IS_FIXED:false;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return ((bool)value) ? IS_FIXED : null;
            }
        } 
