xaml
<DataGrid AutoGenerateColumns="False" ItemsSource="{Binding Items}">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Name" Binding="{Binding Name}"/>
                <DataGridTemplateColumn Header="Icon">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <materialDesign:PackIcon Kind="{Binding IconKind}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
The MainWindow code behind
csharp
public partial class MainWindow : Window
    {
        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Items.Add(new Item
            {
                Name = "Printer",
                IconKind = PackIconKind.Printer
            });
            Items.Add(new Item
            {
                Name = "AbTesting",
                IconKind = PackIconKind.AbTesting
            });
            Items.Add(new Item
            {
                Name = "GoogleHome",
                IconKind = PackIconKind.GoogleHome
            });
        }
    }
    public class Item
    {
        public string Name { get; set; }
        public PackIconKind IconKind { get; set; }
    }
Cheers, Michal.
