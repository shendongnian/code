    public class MainViewModel: INotifyPropertyChanged
        {
            private string inputText;
            public string InputText
            {
                get { return inputText; }
                set
                {
                    if (inputText != value)
                    {
                        inputText = value;
                        PropertyChanged(this, new PropertyChangedEventArgs("InputText"));
                    }
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }
 
     public sealed partial class MainPage : Page
        {
            MainViewModel ViewModel;
    
            public MainPage()
            {
                this.InitializeComponent();
                ViewModel = new Currency_Converter.MainViewModel();
                this.DataContext = ViewModel;
            }
    
        }
