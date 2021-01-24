    <TabControl x:Name="mainTabs">
        <TabControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Header}"/>
            </DataTemplate>
        </TabControl.ItemTemplate>
        <TabControl.ContentTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Content}" />
            </DataTemplate>
        </TabControl.ContentTemplate>
    </TabControl>
---
    public partial class MainWindow : Window
    {
        public ObservableCollection<MyTab> lst { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            // Read tabs data from xml file
            //lst = ReadTabsFromXml();
            lst = new ObservableCollection<MyTab>();
            lst.Add(new MyTab() { Header = "Tab1", Content = "Content1" });
            lst.Add(new MyTab() { Header = "Tab2", Content = "Content2" });
            lst.Add(new MyTab() { Header = "Tab3", Content = "Content3" });
            lst.Add(new MyTab() { Header = "Tab4", Content = "Content4" });
            mainTabs.ItemsSource = lst;
        }
        public class MyTab
        {
            public string Header { get; set; }
            public string Content { get; set; }
        }
    }
