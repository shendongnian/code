    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;
    
    namespace WpfApp11
    {
        public partial class MainWindow : Window
        {
            public ObservableCollection<Entity> Entities { get; set; }
            private int tempIndex = 1; // Always move box "2"
    
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
    
                Entities = new ObservableCollection<Entity>()
                {
                    new Entity() { Name = "1", X=50, Y=50  },
                    new Entity() { Name = "2", X=150, Y=50  },
                    new Entity() { Name = "3", X=50, Y=150  },
                    new Entity() { Name = "4", X=150, Y=150  },
                };
            }
    
            private void myCanvas_MouseMove(object sender, MouseEventArgs e)
            {
            }
    
            private void myCanvas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
            {
            }
    
            private void myCanvas_MouseDown(object sender, MouseButtonEventArgs e)
            {
            }
    
            private void myCanvas_MouseUp(object sender, MouseButtonEventArgs e)
            {
                Point point = Mouse.GetPosition(sender as FrameworkElement);
                if (e.LeftButton == MouseButtonState.Released)
                {
                    Entities[tempIndex].X = (int)point.X;
                    Entities[tempIndex].Y = (int)point.Y;
                }
            }
        }
    
        public class Entity : INotifyPropertyChanged
        {
            #region INotifyPropertyChanged
            public event PropertyChangedEventHandler PropertyChanged;
            protected bool SetProperty<T>(ref T field, T value, [CallerMemberName]string name = null)
            {
                if (Equals(field, value))
                {
                    return false;
                }
                field = value;
                this.OnPropertyChanged(name);
                return true;
            }
            protected void OnPropertyChanged([CallerMemberName]string name = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
            #endregion
    
            #region Property string Name
            private string _Name;
            public string Name { get { return _Name; } set { SetProperty(ref _Name, value); } }
            #endregion
    
            #region Property int X
            private int _X;
            public int X { get { return _X; } set { SetProperty(ref _X, value); } }
            #endregion
    
            #region Property int Y
            private int _Y;
            public int Y { get { return _Y; } set { SetProperty(ref _Y, value); } }
            #endregion
        }
    }
