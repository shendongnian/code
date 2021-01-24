    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Collections.ObjectModel;
    
    namespace UpdateObservableCollection_47291451
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
    
            DataGrid dg = new DataGrid();
            Button btn = new Button();
            ObservableCollection<VoucherDetail> datasource = new ObservableCollection<VoucherDetail>();
            public MainWindow()
            {
                InitializeComponent();
                dg.Height = 200;
                dg.Width = 500;
                MainGrid.Children.Add(dg);//add DataGrid to page
                btn.Content = "Click me";
                btn.Click += Btn_Click;
                btn.Height = 25;
                btn.Width = 50;
                MainGrid.Children.Add(btn);//add button to page
    
                dg.ItemsSource = datasource;//bind grid to data
                
                //create initial data records
                for (int i = 0; i < 5; i++)
                {
                    datasource.Add(new UpdateObservableCollection_47291451.VoucherDetail { Credit = i, Debit = i, DefinitiveID = i, LedgerID = i });
                }
            }
    
            private void Btn_Click(object sender, RoutedEventArgs e)
            {
                //if a record with DefinitiveID of 1 exist, then update the entry
                if (datasource.Select(p => p.DefinitiveID == 1) != null)
                {
                    datasource.FirstOrDefault(p => p.DefinitiveID == 1).Credit = 1234;
                    dg.Items.Refresh();
                }
            }
        }
    
    
        internal class VoucherDetail
        {
            public decimal LedgerID { get; set; }
            public decimal DefinitiveID { get; set; }
            public decimal Debit { get; set; }
            public decimal Credit { get; set; }
        }
    
    
    }
