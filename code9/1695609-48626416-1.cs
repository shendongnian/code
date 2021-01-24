    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="200"></ColumnDefinition>
            <ColumnDefinition Width="300*"></ColumnDefinition>
        </Grid.ColumnDefinitions>
        <StackPanel>
            <Button x:Name="btnFirstStep" Command="{Binding NavigateCommand}" CommandParameter="firstStep" Content="firstStep"/>
            <Button x:Name="btnSecondStep" Command="{Binding NavigateCommand}" CommandParameter="secondStep" Content="secondStep"/>
        </StackPanel>
        <ContentControl Content="{Binding CurrentStep}" Grid.Column="1">
            <ContentControl.Resources>
                <DataTemplate DataType="{x:Type local:FirstStep}">
                    <TextBlock>first...</TextBlock>
                </DataTemplate>
                <DataTemplate DataType="{x:Type local:SecondStep}">
                    <TextBlock>second...</TextBlock>
                </DataTemplate>
            </ContentControl.Resources>
        </ContentControl>
    </Grid>
----------
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
