    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    
    namespace WpfApp1
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
    
                DataContext = new SampleViewModel();
            }
        }
    
        public sealed class SampleViewModel : INotifyPropertyChanged
        {
            private double _value1;
            private double _value2;
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public double Value1
            {
                get { return _value1; }
                set
                {
                    if (_value1 == value)
                        return;
    
                    _value1 = value;
                    OnPropertyChanged(nameof(Value1));
                    _value2 = Math.Round(100 / 1.5 * value, 1);
                    OnPropertyChanged(nameof(Value2));
                }
            }
    
            public double Value2
            {
                get { return _value2; }
                set
                {
                    if (_value2 == value)
                        return;
    
                    _value2 = value;
                    OnPropertyChanged(nameof(Value2));
                    _value1 = Math.Round(1.5 /100* value, 1);
                    OnPropertyChanged(nameof(Value1));
                }
            }
        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
