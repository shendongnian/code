    <Grid Name="GrdContent">
        <TextBlock Name="TheTextBlock" Text="{Binding TextFromParent}" />
    </Grid>
...
    public MainWindow()
            {
                GrdContent.DataContext = this;
    
                InitializeComponent();
    
                SomeText = "New Text!";
            }
