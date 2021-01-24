    using System.Collections.Generic;
    using System.Windows;
    
    namespace PassingValuesFromFormToForm_45425412
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            List<dgvEntry> dgvList = new List<dgvEntry>();
            public MainWindow()
            {
                InitializeComponent();
                dgvList.Add(new PassingValuesFromFormToForm_45425412.dgvEntry { col1 = "blah blah", col2 = "blehbleh" });
                dataGrid.AutoGenerateColumns = true;
                dataGrid.ItemsSource = dgvList;
            }
    
            private void button_Click(object sender, RoutedEventArgs e)
            {
                Window1 win1 = new Window1((dgvEntry)dataGrid.Items[0]);
                win1.Show();
            }
        }
    
        public class dgvEntry {
            public string col1 { get; set; }
            public string col2 { get; set; }
        }
    }
