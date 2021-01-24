    Write code behind like this....
            public MainWindow()
            {
                InitializeComponent();
                List<Great> p = new List<Great>();
                p.Add(new Great() { Name = "Good" });
                p.Add(new Great() { Name = "Bad" });
                p.Add(new Great() { Name = "Ugly" });
                orders.ItemsSource = p;
    
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                List<Great> SelectedOrders = new List<Great>();
                for (int i = 0; i < orders.SelectedItems.Count; i++)
                {
                    SelectedOrders.Add((Great)orders.SelectedItems[i]);
                }
                var kk = orders.ItemsSource as List<Great>;
                foreach (var item in SelectedOrders)
                {
                    kk.Remove(item);
                }
                orders.Items.Refresh();
            }
    
           public class Great
            {
                public string Name { get; set; }
            }
