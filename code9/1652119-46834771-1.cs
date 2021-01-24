    public partial class MyPage:Page
    {
        public MyPage()
        {
            InitializeDataGrid();
            Loaded += MyPage_Loaded;
        }
        private void MyPage_Loaded(object sender, RoutedEventArgs e)
        {
            //_dataGrid.ItemsSource = xxx;
        }
        private void InitializeDataGrid()
        {
            // <DataGrid x:Name="dg" AutoGenerateColumns="False">
            //    <DataGrid.Columns>
            //        <DataGridTemplateColumn>
            //            <DataGridTemplateColumn.CellTemplate>
            //                <DataTemplate>
            //                    <StackPanel Orientation="Horizontal">
            //                        <TextBlock Text="{Binding ValueA}" />
            //                        <TextBlock Text="{Binding ValueB}" />
            //                    </StackPanel>
            //                </DataTemplate>
            //            </DataGridTemplateColumn.CellTemplate>
            //        </DataGridTemplateColumn>
            //    </DataGrid.Columns>
            //</DataGrid>
            // StackPanel and Children
            var stackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
            stackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            var textBlockFactoryA = new FrameworkElementFactory(typeof(TextBlock));
            textBlockFactoryA.SetBinding(TextBlock.TextProperty, new Binding("ValueA"));
            var textBlockFactoryB = new FrameworkElementFactory(typeof(TextBlock));
            textBlockFactoryB.SetBinding(TextBlock.TextProperty, new Binding("ValueB"));
            stackPanelFactory.AppendChild(textBlockFactoryA);
            stackPanelFactory.AppendChild(textBlockFactoryB);
            // DataTemplate
            var dataTemplate = new DataTemplate
            {
                VisualTree = stackPanelFactory
            };
            // DataGridTemplateColumn
            var templateColumn = new DataGridTemplateColumn
            {
                CellTemplate = dataTemplate
            };
            _dataGrid.Columns.Add(templateColumn);
            // DataGrid
            _dataGrid.Name = "gd";
            _dataGrid.AutoGenerateColumns = true;
        }
        private readonly DataGrid _dataGrid = new DataGrid();
    }
