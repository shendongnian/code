    public partial class MainWindow : Window
    {
        private const string _fileName = "phonebook.txt";
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                //create a List<Item> that contains the data from the file on a background thread
                Task.Run(() => LoadData()).ContinueWith(task =>
                {
                    //...and set the ItemsSource property of the DataGrid to the returned List<Item>
                    dataGrid.ItemsSource = task.Result;
                }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
            };
            this.Closing += (s, e) => SaveData();
        }
        public List<Item> LoadData()
        {
            List<Item> items = new List<Item>();
            if (System.IO.File.Exists(_fileName))
            {
                string[] lines = System.IO.File.ReadAllLines(_fileName);
                foreach (string line in lines)
                {
                    string[] columns = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    if (columns.Length == 2)
                    {
                        items.Add(new Item()
                        {
                            Name = columns[0],
                            Number = columns[1]
                        });
                    }
                }
            }
            else
            {
                //populate the DataGrid with some default data...
                items.Add(new Item { Name = "Name1", Number = "000-111" });
                items.Add(new Item { Name = "Name2", Number = "111-222" });
            }
            return items;
        }
        private void SaveData()
        {
            IEnumerable<Item> items = dataGrid.ItemsSource as IEnumerable<Item>;
            if (items != null)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(_fileName))
                    foreach (Item item in items)
                        sw.WriteLine($"{item.Name};{item.Number}");
            }
        }
    }
