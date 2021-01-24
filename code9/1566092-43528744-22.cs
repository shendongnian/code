        <Grid>
            <TabControl x:Name="actionTabs" DockPanel.Dock="Right" Background="White">
                <TabControl.ItemTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Horizontal" Height="21" Width="100">
                            <TextBlock Width="80" Text="{Binding Header}"/>
                            <Image Source="PathToFile\close.png" Width="20" Height="20" MouseDown="Image_MouseDown"/>
                        </StackPanel>
                    </DataTemplate>
                </TabControl.ItemTemplate>
                <TabControl.ContentTemplate>
                    <DataTemplate>
                        <UserControl Height="800" Width="1220" Content="{Binding Content}" Margin="0" HorizontalAlignment="Stretch" VerticalAlignment="Stretch" />
                    </DataTemplate>
                </TabControl.ContentTemplate>
            </TabControl>
        </Grid>
<!-- end 
*In the code behind*
      
    public partial class Window1 : Window
    {
        private ActionTabViewModal vmd;
        public Window1()
        {
            InitializeComponent();
            // Initialize viewModel
            vmd  = new ActionTabViewModal();
            // Bind the xaml TabControl to view model tabs
            actionTabs.ItemsSource = vmd.Tabs;
            // Populate the view model tabs
            vmd.Populate();
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        { 
            // This event will be thrown when on a close image clicked
            vmd.Tabs.RemoveAt(actionTabs.SelectedIndex);
        }
    }
**Result:**
[![][2]][2]
  [1]: http://www.wpf-tutorial.com/panels/stackpanel/
  [2]: https://i.stack.imgur.com/0ZLFK.jpg
