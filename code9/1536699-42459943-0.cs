    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    namespace ListBoxUpdate
    {
        public partial class Window1 : Window
        {
            public ObservableCollection<StringWrapper> Strings { get; set; }
            
            public class StringWrapper 
            {
                public string Content { get; set; }
                
                public StringWrapper(string content)
                {
                    this.Content = content;
                }
                
                public static implicit operator StringWrapper(string content)
                {
                    return new Window1.StringWrapper(content);
                }
            }
            
            public Window1()
            {
                InitializeComponent();
                
                this.Strings = new ObservableCollection<StringWrapper>(new StringWrapper[] { "one", "two", "three" });
                this.DataContext = this;
            }
            
            void HandleButtonClick(object sender, RoutedEventArgs e)
            {
                string text = "";
                
                for (int i = 0; i < Strings.Count; i++) {
                    text += Strings[i].Content + Environment.NewLine;
                }
                
                textBlock.Text = text;
            }
        }
    }
