    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Collections.Generic;
    
    namespace WpfApp
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                List<PhoneClient> clients = new List<PhoneClient>();
                clients.Add(new PhoneClient() { Name = "Kumar", Number = "0101010", Extension = "555", State = "New York" });
                clients.Add(new PhoneClient() { Name = "Shanaya", Number = "1010101", Extension = "555", State = "New Jersey" });
                clients.Add(new PhoneClient() { Name = "Billy Bob", Number = "6543210", Extension = "555", State = "Single" });
    
                lv_clients.ItemsSource = clients;
            }
    
            public class PhoneClient
            {
                public String Name { get; set; }
                public String Number { get; set; }
                public String Extension { get; set; }
                public String State { get; set; }
                public String DisplayString
                {
                    get
                    {
                        return String.IsNullOrEmpty(Name) ? Number : String.Format("{0} ({1})", Name, Extension);
                    }
                }
            }
    
            private void mn_call_Click(object sender, RoutedEventArgs e)
            {
                MenuItem currentMenuItem = (MenuItem)sender;
                string number = (string)currentMenuItem.DataContext;
                MessageBox.Show("Number " + number);
            }
    
            private void Button_ListItem_Click(object sender, RoutedEventArgs e)
            {
                Button currentButton = (Button)sender;
                PhoneClient data = (PhoneClient)currentButton.DataContext;
                MessageBox.Show(data.Name + " tapped");
            }
        }
    }
