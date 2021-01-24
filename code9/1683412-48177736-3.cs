    using System;
    using System.Windows;
    
    namespace TimingLostFocus
    {
        public partial class MainWindow : Window
        {
            public static int WindowsCount = 0;
            public MainWindow()
            {
                InitializeComponent();
    
                if (Application.Current is App app)
                {
                    app.PropertyChanged += (s, e) =>
                    {
                        if (e.PropertyName == nameof(App.MillisecondsWithoutFocus))
                        {
                            Dispatcher.BeginInvoke(new Action(() => millisecondsWithoutFocusTextBlock.Text = app.MillisecondsWithoutFocus.ToString()));
                        }
                    };
                }
            }
        }
    }
