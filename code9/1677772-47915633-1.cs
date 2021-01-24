    using System.Collections.ObjectModel;
    using System.Windows;
    
    namespace WpfTest
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
                AddNew(null, null);
            }
    
            public ObservableCollection<MyItem> MyItems { get; set; } = new ObservableCollection<MyItem>();
    
            private void AddNew(object sender, RoutedEventArgs e)
            {
                MyItems.Add(new MyItem
                {
                    Name = "SPMASV-KL16SQD1",
                    CPU = 4,
                    RAM = 8192,
                    IP = "10.10.40.79",
                    Subnet = "255.255.252.0",
                    PortGroup = "Server231",
                    Gateway = "10.10.40.254",
                    DNS = "10.10.40.69",
                    Description = "Testing",
                    Template = "OAK 2016 Template",
                    Host = "LAX",
                    Site = "LAX",
                    Folder = "Servers",
                    Datastore = "OakStorMagic",
                    Patch = "Patch Reboot",
                    HDD1Size = 320,
                    HDD1Format = "Thick",
                    HDD2Size = 200,
                    HDD2Format = "Thin",
                    HDD3Size = 60,
                    HDD3Format = "Thick",
                    HDD4Size = 500,
                    HDD4Format = "Thin",
                    HDD5Size = 1350,
                    HDD5Format = "EagerZeroedThick"
                });
            }
    
            private void Export(object sender, RoutedEventArgs e)
            {
                foreach (var myItem in MyItems)
                {
                    //do whatever you need to export your data...
                }
            }
        }
    }
