    <Application
        x:Class="App4.UWP.App"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="using:App4.UWP"
        RequestedTheme="Light">
        <Application.Resources>
            <ResourceDictionary>
                <DataTemplate x:Key="MyCellTemplate">
                    <StackPanel>
                        <Grid>
                            <Grid.Resources>
                                <local:ImageExtensionConverter x:Name="ImageExtensionConverter" />
                            </Grid.Resources>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="0.2*" />
                                <ColumnDefinition Width="*" />
                            </Grid.ColumnDefinitions>
                            <Grid.RowDefinitions>
                                <RowDefinition Height="35" />
                            </Grid.RowDefinitions>
                            <TextBlock Grid.Column="1" Text="{Binding Name}" FontSize="18" />
                            <Image Grid.Column="0" Source="{Binding ImageFilename, Converter={StaticResource ImageExtensionConverter}}" Height="30" />
                        </Grid>
                    </StackPanel>
                </DataTemplate>
            </ResourceDictionary>
        </Application.Resources>
    </Application>
