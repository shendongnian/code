    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    
    namespace WpfApp9
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                // Setup the ViewModels
                var vmA = new ViewModelA();
                var vmB = new ViewModelB();
    
                // Test ViewModelB
                vmB.DoIt();
            }
        }
    
        public class MainModel : INotifyPropertyChanged
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
    
            #region Property List<ISystem> SystemsList
            private List<ISystem> _SystemsList;
            public List<ISystem> SystemsList { get { return _SystemsList; } set { SetProperty(ref _SystemsList, value); } }
            #endregion
    
            #region Property IComMethod ComMethodA
            private IComMethod _ComMethodA;
            public IComMethod ComMethodA { get { return _ComMethodA; } set { SetProperty(ref _ComMethodA, value); } }
            #endregion
    
            public MainModel()
            {
                SystemsList = new List<ISystem>() { new Systems() };
                ComMethodA = new ClassC();
            }
        }
    
        public interface ISystem
        {
            IComMethod ComMethodB { get; set; }
        }
        public interface IComMethod : INotifyPropertyChanged
        {
            bool isOpen { get; set; }
        }
    
        public class Systems : ISystem, INotifyPropertyChanged
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
    
            #region Property IComMethod ComMethodB
            private IComMethod _ComMethodB;
            public IComMethod ComMethodB { get { return _ComMethodB; } set { SetProperty(ref _ComMethodB, value); } }
            #endregion
    
            public Systems()
            {
                ComMethodB = new ClassC();
            }
        }
    
        public class ClassC : IComMethod, INotifyPropertyChanged
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
    
            #region Property bool isOpen
            private bool _isOpen;
            public bool isOpen { get { return _isOpen; } set { SetProperty(ref _isOpen, value); } }
            #endregion
        }
    
        public class ViewModelBase : INotifyPropertyChanged
        {
            public static MainModel MainModel { get; } = new MainModel();
    
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
        }
    
        public class ViewModelA : ViewModelBase
        {
            public ViewModelA()
            {
                MainModel.SystemsList[0].ComMethodB.PropertyChanged += ComMethodB_PropertyChanged;
                MainModel.ComMethodA.PropertyChanged += ComMethodA_PropertyChanged;
            }
    
            private void ComMethodB_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                MessageBox.Show("TextB");
            }
    
            private void ComMethodA_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                MessageBox.Show("TextA");
            }
        }
    
        public class ViewModelB : ViewModelBase
        {
            public ViewModelB()
            {
            }
    
            public void DoIt()
            {
                MainModel.ComMethodA.isOpen = true; // this fired off the "TextA" messagebox
                MainModel.SystemsList[0].ComMethodB.isOpen = true; // this fired off the "TextB" messagebox
            }
        }
    }
