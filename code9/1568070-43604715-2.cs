    using System.Windows;
    using System.Windows.Controls;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;
    using System;
    namespace MYNAMESPACE
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            // To initialise the List and use it outside the class
            //MyListItem instanceOfClass = new MyListItem();
            //List<CheckBoxListItem> listOfItems = instanceOfClass.MyMethod();
            //listBox1.ItemsSource = listOfItems;
        }
        public class CheckBoxListItem : INotifyPropertyChanged
        {
            public bool CheckStatus { get; set; }
            public string Text { get; set; }
            public CheckBoxListItem(bool _CheckStatus, string _Text)
            {
                CheckStatus = _CheckStatus;
                Text = _Text;
            }
            
            public event PropertyChangedEventHandler PropertyChanged;
        }
        public class MyListItem
        {
            public List<CheckBoxListItem> MyMethod()
            {
                List<CheckBoxListItem> items = new List<CheckBoxListItem>();
                items.Add(new CheckBoxListItem(false, "Item 1"));
                items.Add(new CheckBoxListItem(false, "Item 2"));
                items.Add(new CheckBoxListItem(false, "Item 3"));
                return items;
            }
        }
        
        public List<string> selectedNames = new List<string>();
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            var item = checkBox.Content;
            bool isChecked = checkBox.IsChecked.HasValue ? checkBox.IsChecked.Value : false;
            if (isChecked)
                selectedNames.Add(item.ToString());
            else
                selectedNames.Remove(item.ToString());
        }
        public string selections;
        bool updatedItems;
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (string selection in selectedNames)
            {
                selections += selection + Environment.NewLine;
                if (!listBox2.Items.Contains(selection))
                {
                    listBox2.Items.Add(selection);
                    updatedItems = true;
                }
                else if (listBox2.Items.Contains(selection))
                {
                    updatedItems = false;
                }
            }
            if (updatedItems == true)
                MessageBox.Show("Add items are: " + selections);
            else if (updatedItems == false)
                MessageBox.Show("No update to selection was made.");
        }
        private void CheckStatus(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        }
       }
