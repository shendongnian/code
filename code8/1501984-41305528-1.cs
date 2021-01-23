    <Window
        x:Class="ComboboxInDataGrid.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        Title="MainWindow"
        Width="525"
        Height="350"
        mc:Ignorable="d">
        <Grid>
            <DataGrid x:Name="me"
                HorizontalAlignment="Left"
                AutoGenerateColumns="False"
                CanUserAddRows="False"
                ItemsSource="{Binding Path=WorldDataList}"
                SelectedItem="{Binding SelectedWorldData}">
                <DataGrid.Columns>
                    <DataGridTemplateColumn Header="Country">
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <Grid>
                                    <ComboBox ItemsSource="{Binding RelativeSource={RelativeSource FindAncestor, 
                                                                                                   AncestorType={x:Type DataGrid}},
                                                                    Path=DataContext.Countries}"
                                              SelectedItem="{Binding Path=Country, 
                                                                     Mode=TwoWay,
                                                                     UpdateSourceTrigger=PropertyChanged}" />
                                </Grid>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>
        </Grid>
    </Window>
    using System.Collections.Generic;
    using System.Windows;
    namespace ComboboxInDataGrid
    {
        public partial class MainWindow : Window
        {
            public MainWindow ()
            {
                DataContext = new WorldDataViewModel ();
                InitializeComponent ();
            }
        }
        class WorldDataViewModel
        {
            public WorldDataViewModel ()
            {
                var c1 = "USA";
                var c2 = "Canada";
                var c3 = "Brasil";
                var c4 = "Brasfsdfsil";
                Countries = new List<string> ();
                Countries.Add (c1);
                Countries.Add (c2);
                Countries.Add (c3);
                Countries.Add (c4);
                _worldDataList.Add (new WorldData { Index = 1, Country = c2 });
                _worldDataList.Add (new WorldData { Index = 2, Country = c3 });
                _worldDataList.Add (new WorldData { Index = 3, Country = c4 });
            }
            private List<WorldData> _worldDataList = new List<WorldData> ();
            public List<WorldData> WorldDataList
            {
                get
                {
                    return _worldDataList;
                }
                set
                {
                    _worldDataList = value;
                }
            }
            public List<string> Countries { get; set; }
            private WorldData worldData;
            public WorldData SelectedWorldData
            {
                get
                {
                    return worldData;
                }
                set
                {
                    worldData = value;
                }
            }
        }
        public class WorldData
        {
            public int Index { get; set; }
            private string country;
            public string Country
            {
                get { return country; }
                set
                {
                    country = value;
                }
            }
        }
    }
