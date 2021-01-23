    <Grid>
        <StackPanel>
            <StackPanel Orientation="Horizontal">
                <ListBox x:Name="ListBox1" DisplayMemberPath="Name"/>
                <ListBox x:Name="ListBox2" DisplayMemberPath="Name"/>
            </StackPanel>
            <Button x:Name="Button" Content="Remove" Click="Button_OnClick"></Button>
        </StackPanel>
        
    </Grid>
    public partial class Window1 : Window
    {
        private ObservableCollection<Person> list1;
        private ObservableCollection<Person> list2;
        public Window1()
        {
            InitializeComponent();
            list1 = new ObservableCollection<Person>()
            {
                new Person() {Name = "NAme1"},
                new Person() {Name = "NAme2"},
                new Person() {Name = "NAme3"},
                new Person() {Name = "NAme4"},
                new Person() {Name = "NAme5"},
            };
            ListBox1.ItemsSource = list1;
            list2 = new ObservableCollection<Person>();
            ListBox2.ItemsSource = list2;
        }
        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            list2.Add(ListBox1.SelectedItem as Person);
            list1.Remove(ListBox1.SelectedItem as Person);
        }
    }
    class Person
    {
        public string Name { get; set; }
    }
