    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    namespace ListBoxUpdate
    {
        public partial class Window1 : Window
        {
            public ObservableCollection<string> Strings { get; set; }
            
            public Window1()
            {
                InitializeComponent();
                
                this.Strings = new ObservableCollection<string>(new string[] { "one", "two", "three" });
                this.DataContext = this;
            }
            
            void HandleButtonClick(object sender, RoutedEventArgs e)
            {
                string text = "";
                
                for (int i = 0; i < Strings.Count; i++) {
                    text += Strings[i] + Environment.NewLine;
                }
                
                textBlock.Text = text;
            }
            
            void HandleTextBoxLostFocus(object sender, RoutedEventArgs e)
            {
                // https://stackoverflow.com/questions/765984/wpf-listboxitems-with-datatemplates-how-do-i-reference-the-clr-object-bound-to?rq=1, @Dennis Troller's answer.
                int index;
                object item;
                DependencyObject container;
                TextBox textBox = sender as TextBox;
                
                if (textBox == null) return;
                
                item = textBox.DataContext;
                container = listBox.ItemContainerGenerator.ContainerFromItem(item);
                
                if (container != null) {
                    index = listBox.ItemContainerGenerator.IndexFromContainer(container);
                    if (textBox.Text != Strings[index]) {
                        Strings[index] = textBox.Text;
                    }
                }
            }
        }
    }
