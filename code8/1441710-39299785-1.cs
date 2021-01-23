MainWindow.xaml
    <Window x:Class="WpfApplication2.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:WpfApplication2"
            mc:Ignorable="d"
            Title="MainWindow" Height="300" Width="525">
        <DockPanel>
            <StackPanel DockPanel.Dock="Top"  Orientation="Vertical">
                <Button Click="Load_Button_Click">Load</Button>
                <Button Click="Clear_Button_Click">Clear</Button>
                <Button Click="Scroll_Button_Click">Scroll</Button>
            </StackPanel>
            <ListView DockPanel.Dock="Bottom" Name="SearchResultListView" ItemsSource="{Binding}">
                <ListView.View>
                    <GridView>
                        <GridViewColumn Header="Name" Width="60" DisplayMemberBinding="{Binding Name}" />
                        <GridViewColumn Header="Age" Width="60" DisplayMemberBinding="{Binding Age}" />
                    <GridViewColumn Header="Email" Width="140" DisplayMemberBinding="{Binding Email}" />
                    </GridView>
                </ListView.View>
                <ListView.Style>
                    <Style TargetType="ListView">
                        <Setter Property="Visibility" Value="Collapsed"/>
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding HasItems, RelativeSource={RelativeSource Self}}" Value="True">
                                <Setter Property="Visibility" Value="Visible"/>
                                <Setter Property="SelectedIndex" Value="0"/>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </ListView.Style>
            </ListView>
        </DockPanel>
    </Window>
    
MainWindow.xaml.cs
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }
        }
        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<User> items = new ObservableCollection<User>();
            SearchResultListView.ItemsSource = items;
        }
        private void Load_Button_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<User> items = new ObservableCollection<User>();
            items.Add(new User() { Name = "Smith", Age = 18, Email = "smith@test.com" });
            items.Add(new User() { Name = "Joe", Age = 19, Email = "joe@test.com" });
            items.Add(new User() { Name = "Walter", Age = 17, Email = "walter@test.com" });
            items.Add(new User() { Name = "Tim1", Age = 44, Email = "tim1@test.com" });
            items.Add(new User() { Name = "Tim2", Age = 44, Email = "tim2@test.com" });
            items.Add(new User() { Name = "Tim3", Age = 44, Email = "tim3@test.com" });
            items.Add(new User() { Name = "Tim4", Age = 44, Email = "tim4@test.com" });
            items.Add(new User() { Name = "Tim5", Age = 44, Email = "tim5@test.com" });
            items.Add(new User() { Name = "Tim6", Age = 44, Email = "tim6@test.com" });
            items.Add(new User() { Name = "Tim7", Age = 44, Email = "tim7@test.com" });
            items.Add(new User() { Name = "Tim8", Age = 44, Email = "tim8@test.com" });
            items.Add(new User() { Name = "Tim9", Age = 44, Email = "tim9@test.com" });
            items.Add(new User() { Name = "Tim10", Age = 44, Email = "tim10@test.com" });
            items.Add(new User() { Name = "Tim11", Age = 44, Email = "tim11@test.com" });
            items.Add(new User() { Name = "Tim12", Age = 44, Email = "tim12@test.com" });
            SearchResultListView.ItemsSource = items;
        }
        private void Scroll_Button_Click(object sender, RoutedEventArgs e)
        {
            if (SearchResultListView.SelectedIndex < this.SearchResultListView.Items.Count - 1)
            {
                SearchResultListView.SelectedIndex++;
                SearchResultListView.ScrollIntoView(this.SearchResultListView.SelectedItem);
            }
            else 
            {
                SearchResultListView.SelectedIndex = 0;
                SearchResultListView.ScrollIntoView(this.SearchResultListView.SelectedItem);
            }
        }
    }
