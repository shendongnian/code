    public partial class MainWindow : Window
    {
        string userdata;
        private ObservableCollection<Users> theUsers = new ObservableCollection<Users>();
        public MainWindow()
        {
            InitializeComponent();
            theListview.ItemsSource = theListview;
        }
        private void PopulateListView()
        {
            using (StreamReader sr = new StreamReader("ops.json"))
            {
                userdata = sr.ReadToEnd();
                List<Users> accounts = JsonConvert.DeserializeObject<List<Users>>(userdata);
                foreach (var account in accounts)
                {
                    theUsers.Add(new Users { Name = account.Name });
                }
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //I got the code done for this part, I wont include it because it will make this too long.
        }
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            Users selectedUser = theListview.SelectedItem as Users;
            if (selectedUser != null)
                theUsers.Remove(selectedUser);
        }
    }
