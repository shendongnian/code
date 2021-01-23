    <Grid>
        <StackPanel>
            <ComboBox x:Name="cbo">
                <ComboBox.ItemTemplate>
                    <DataTemplate DataType="local:MyCombo">
                        <StackPanel Orientation="Horizontal">
                            <CheckBox IsChecked="{Binding IsChecked}"/>
                            <TextBlock Text="{Binding Name}"/>
                        </StackPanel>
                    </DataTemplate>
                </ComboBox.ItemTemplate>
            </ComboBox>
        </StackPanel>
    </Grid>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<MyCombo> lst = new List<MyCombo>();
            for (int i = 0; i < 10; i++)
            {
                lst.Add(new MyCombo() {IsChecked = true,Name = "Name"+i});
            }
            cbo.ItemsSource = lst;
        }
    }
    public class MyCombo
    {
        public bool IsChecked { get; set; }
        public string Name { get; set; }
    }
