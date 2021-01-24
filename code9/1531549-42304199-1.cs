    namespace WpfApplication2
    {
        public enum State
        {
            locked,
            unlock,
            valueIncorrect
        }
    
        public class BaseViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected void NotifyPropertyChanged([CallerMemberName] string prop = null)
            {
                var handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(prop));
                }
            }
        }
    
        public class MyData : BaseViewModel
        {
            private State _Data1State;
            public State Data1State
            {
                get { return _Data1State; }
                set
                {
                    if (_Data1State != value)
                    {
                        _Data1State = value;
                        NotifyPropertyChanged();
                    }
                }
            }
        }
    
        public class StateToBorderBrushConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value is State)
                {
                    var s = (State)value;
                    switch (s)
                    {
                        case State.locked:
                            return new SolidColorBrush(Colors.Red);
                        case State.unlock:
                            return new SolidColorBrush(Colors.Green);
                        case State.valueIncorrect:
                            return new SolidColorBrush(Colors.White);
                        default:
                            break;
                    }
                }
                return new SolidColorBrush(Colors.Transparent);
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    
    
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private MyData ContextData;
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                ContextData = new MyData { Data1State = State.locked };
                grid1.DataContext = ContextData;
            }
    
            private void ChangeStateButton_Click(object sender, RoutedEventArgs e)
            {
                switch (ContextData.Data1State)
                {
                    case State.locked:
                        ContextData.Data1State = State.unlock;
                        break;
                    case State.unlock:
                        ContextData.Data1State = State.valueIncorrect;
                        break;
                    case State.valueIncorrect:
                        ContextData.Data1State = State.locked;
                        break;
                    default:
                        ContextData.Data1State = State.locked;
                        break;
                }
            }
        }
    }
