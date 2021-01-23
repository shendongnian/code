      XAML Code:
    
    <!-- begin snippet: js hide: false console: true babel: false -->
    
    <!-- language-all: lang-c# -->
    
     
    
    <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="Auto" />
                <ColumnDefinition Width="Auto"/>
            </Grid.ColumnDefinitions>
            <DataGrid Name="basketNameDataGrid" AutoGenerateColumns="False" CanUserResizeRows="False"
                      CanUserAddRows="False">
                <DataGrid.RowStyle>
                    <Style TargetType="DataGridRow">
                        <Setter Property="Height" Value="{Binding RowHeight}"></Setter>
                    </Style>
                </DataGrid.RowStyle>
                <DataGrid.Columns>
                    <DataGridTemplateColumn Header="Basket">
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding Name}" VerticalAlignment="Center"/>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>
            <DataGrid Name="itemDataGrid" Grid.Column="1" AutoGenerateColumns="False" HeadersVisibility="Column" 
                      CanUserResizeRows="False" CanUserAddRows="False">
                <DataGrid.RowStyle>
                    <Style TargetType="DataGridRow">
                        <Setter Property="Height" Value="20"></Setter>
                    </Style>
                </DataGrid.RowStyle>
                <DataGrid.Columns>
                    <DataGridTemplateColumn Header="Item Name">
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding Name, Mode = OneWay}"/>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                        </DataGridTemplateColumn>
                    <DataGridTextColumn Header="Price" Binding="{Binding Price, Mode = OneWay}" CanUserSort="False"></DataGridTextColumn>
                </DataGrid.Columns>
            </DataGrid>
        </Grid>
    
    <!-- end snippet -->
        
     C# code - I have three classes for data.       
    
    <!-- begin snippet: js hide: false console: true babel: false -->
    
    <!-- language: lang-cs -->
    
        class Item
         { 
            public Name {get;}
            public Price {set;}
         }
                
        class Basket : List<Item>
         {  
            public Name {get;}
         }   
    
        class BasketCollection : List<Baske
         {
         }          
    
    <!-- end snippet -->
    
    Code behind in MainWindow.cs
    
    <!-- begin snippet: js hide: false console: true babel: false -->
    
    <!-- language: lang-cs -->
    
      
    
          public MainWindow()
                    {
                        InitializeComponent();
        
                        var baskets = GetData();
        
                        int rowHeight = 20; //// itemDataGrid row height is 20 in xaml
        
                        //// Create a list of annonymous type with properties Name an RowHeight.
                        //// RowHeight = Height of one row * number of items in current basket.
                        var basketNameData = baskets.Select(x => new { Name = x.Name, RowHeight = rowHeight * x.Count });
        
                        //// Assign data to first DataGrid 
                        basketNameDataGrid.ItemsSource = basketNameData.ToList();
        
                        //// Get list of  all Items in all baskets and assign as ItemsSource to second datagrid
                        itemDataGrid.ItemsSource = baskets.SelectMany(basket => basket).ToList();
                    }
        
                    /// <summary>
                    /// Gets some data to bind to view
                    /// </summary>
                    /// <returns>Basket Collection</returns>
                    private BasketCollection GetData()
                    {
                        var baskets = new BasketCollection();
        
                        var fruitBasket = new Basket("Fruit");
                        fruitBasket.Add(new Item("Alphonso Mango", 80));
                        fruitBasket.Add(new Item("Nagpur Orange", 10));
                        fruitBasket.Add(new Item("Dragon Fruit", 50));
        
                        var vegetableBasket = new Basket("Vegetable");
                        vegetableBasket.Add(new Item("Brinjal", 5));
                        vegetableBasket.Add(new Item("Broccoli", 5));
                        vegetableBasket.Add(new Item("Onion", 3)); 
        
                        baskets.Add(fruitBasket);
                        baskets.Add(vegetableBasket);
        
                        return baskets;
                    }
    
    <!-- end snippet -->
    
  
