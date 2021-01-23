    <Grid>
        <StackPanel>
            <ListBox x:Name="list" Height="200"
            SelectionMode="Extended"
            ItemsSource="{Binding SampleItems}" >
            </ListBox>
            <Button  Content="Remove" Command="{Binding DeleteCommand}"
            CommandParameter="{Binding ElementName=list, Path=SelectedItems}">
            </Button>
        </StackPanel>
    </Grid>
     public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel1();
        }
    }
    public class MainViewModel1
    {
        private ObservableCollection<string> m_items;
        public ObservableCollection<string> SampleItems
        {
            get { return m_items; }
            set { m_items = value; }
        }
        public ICommand DeleteCommand { get; private set; }
        public MainViewModel1()
        {
            DeleteCommand = new RelayCommand<object>(Delete, CanDelete);
            var items = new ObservableCollection<string>();
            var today = DateTime.Now;
            for (int i = 1; i <= 10; i++)
            {
                items.Add("Test"+i);
            }
            SampleItems = items;
        }
        private void Delete(object obj)
        {
            var items = new ObservableCollection<string>();
            foreach (var item in (IList)obj)
            {
                items.Add((string)item);
            }
            foreach (var item in items)
            {
                m_items.Remove(item);
            }
        }
        private bool CanDelete(object obj)
        {
            return true;
        }
    }
