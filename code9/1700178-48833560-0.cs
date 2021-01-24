    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PersonCollection = new ObservableCollection<Person>()
            {
                new Person() { FirstName = "John", LastName = "Doe" },
                new Person() { FirstName = "Richard", LastName = "Bryson" },
                new Person() { FirstName = "Bill", LastName = "Gates" },
                new Person() { FirstName = "Adam", LastName = "Sandler" }
            };
            itemsControl.ItemsSource = PersonCollection;
        }
        public ObservableCollection<Person> PersonCollection { get; set; }
    }
---
    <ItemsControl x:Name="itemsControl">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid Margin="0,0,0,5">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*" />
                        <ColumnDefinition Width="*" />
                    </Grid.ColumnDefinitions>
                    <TextBlock Grid.Column="0" Text="{Binding Path=FirstName}" />
                    <TextBlock Grid.Column="1" Text="{Binding Path=LastName}" />
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
