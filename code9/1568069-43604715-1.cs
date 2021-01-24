    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<CheckBoxListItem> items1 = new List<CheckBoxListItem>();
            items1.Add(new CheckBoxListItem(false, "Item 1"));
            items1.Add(new CheckBoxListItem(false, "Item 2"));
            items1.Add(new CheckBoxListItem(false, "Item 3"));
            lstExclude.ItemsSource = items1;
        }
        public string selections = "";
        public class CheckBoxListItem
        {
            public bool Checked { get; set; }
            public string Text { get; set; }
            public CheckBoxListItem(bool ch, string text)
            {
                Checked = ch;
                Text = text;
            }
        }
        public void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var cb = sender as CheckBox;
            var item = cb.DataContext;
            lstExclude.SelectedItem = item;
            selections = ((CheckBoxListItem)(cb.DataContext)).Text;
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Selections.Items.Add(selections);
        }
    }
