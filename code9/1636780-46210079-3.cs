    using System.Collections.Generic;
    using System.IO;
    using System.Windows;
    
    namespace StackAnswerWPF
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void GetText(object sender, RoutedEventArgs e)
            {
                var source = File.ReadAllLines("C:\\Users\\User\\Desktop\\Test.txt");
    
                MainListBox.ItemsSource = null;
    
                List<string> result = new List<string>();
                for (int i = 0; i < source.Length; i++)
                {
                    if (source[i].StartsWith("D")
                        && !source[i - 1].StartsWith("D"))
                    {
                        result.Add(source[i - 2]);
                        result.Add(source[i - 1]);
                        result.Add(source[i]);
                    }
                    else if (source[i].StartsWith("D"))
                    {
                        result.Add(source[i]);
                    }
                }
                MainListBox.ItemsSource = result;
            }
        }
    }
