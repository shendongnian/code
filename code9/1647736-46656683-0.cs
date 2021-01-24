    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Documents;
    
    namespace WpfApp1
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
    
                DataContext = new[]
                {
                    new Example {Company = "Google", Url = "http://www.google.com"},
                    new Example {Company = "Amazon", Url = "http://www.amazon.com"}
                };
            }
    
            private void HyperlinkClick(object sender, RoutedEventArgs e)
            {
                var link = (Hyperlink) e.OriginalSource;
                Process.Start(link.NavigateUri.AbsoluteUri);
            }
        }
    
        internal class Example
        {
            public string Company { get; set; }
            public string Url { get; set; }
        }
    }
