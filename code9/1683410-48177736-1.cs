    using System;
    using System.ComponentModel;
    using System.Timers;
    using System.Windows;
    
    namespace TimingLostFocus
    {
        public partial class App : Application, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private long millisecondsWithoutFocus;
            private void Application_Startup(object sender, StartupEventArgs eventArgs) => Timer.Elapsed += (s, e) => MillisecondsWithoutFocus++;
            private void Application_Activated(object sender, EventArgs e) => Timer.Stop();
            private void Application_Deactivated(object sender, EventArgs e) =>Timer.Start();
            public Timer Timer { get; set; } = new Timer(100);
    
            public long MillisecondsWithoutFocus
            {
                get => millisecondsWithoutFocus;
                set
                {
                    millisecondsWithoutFocus = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MillisecondsWithoutFocus)));
                }
            }
        }
    }
