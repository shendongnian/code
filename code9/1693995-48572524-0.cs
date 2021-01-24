    <Window x:Class="WpfApp13.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:WpfApp13"
            xmlns:converters="clr-namespace:WpfApp13"
            mc:Ignorable="d"
            Title="MainWindow" Height="600" Width="525">
        <Window.Resources>
            <converters:TestConverter x:Key="TestConverter" />
            <converters:TimeSpanFormatConverter x:Key="TimeSpanFormatConverter" />
        </Window.Resources>
        <Window.DataContext>
            <local:MainWindowViewModel />
        </Window.DataContext>
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="*" />
                <RowDefinition Height="*" />
                <RowDefinition Height="Auto" />
            </Grid.RowDefinitions>
            <!-- Since it looks like you want to play audio, I set SelectionMode to Single. Probably don't want to play multiple at once -->
            <ListView Name="lvListView" Margin="0,0,0,35" AllowDrop="True" ItemsSource="{Binding FilesCollection}" SelectionMode="Single">
                <!--<ia:Interaction.Triggers>
                    <ia:EventTrigger EventName="Drop">
                        <cmd:EventToCommand Command="{Binding ListViewFileDrop}" PassEventArgsToCommand="True"/>
                    </ia:EventTrigger>
                    <ia:EventTrigger EventName="MouseDoubleClick">
                        <cmd:EventToCommand Command="{Binding ListViewDoubleClickCommand}" PassEventArgsToCommand="True"/>
                    </ia:EventTrigger>
                </ia:Interaction.Triggers>-->
    
                <ListView.ContextMenu>
                    <ContextMenu>
                        <MenuItem Header="Remove" Command="{Binding RemoveCommand}" CommandParameter="{x:Reference Name=lvListView}"/>
    
                        <MenuItem Header="Add File"  Command="{Binding BrowseCommand}"/>
    
                        <MenuItem Header="Clear All"  Command="{Binding ClearAllCommand}"/>
                    </ContextMenu>
                </ListView.ContextMenu>
    
                <ListView.ItemContainerStyle>
                    <Style TargetType="ListViewItem">
                        <Setter Property="Background"  Value="Beige"/>
                        <!-- The converter, TestConverter, isn't even needed but I'll leave it since you might be doing something else with it -->
                        <Setter Property="IsSelected" Value="{Binding Path=IsPlaying, Converter={StaticResource TestConverter}}"/>
                        <Style.Triggers>
                            <!--<Trigger Property="IsSelected" Value="True">-->
                            <Trigger Property="IsSelected" Value="True">
                                <Setter Property="Background" Value="Yellow"/>
                            </Trigger>
                        </Style.Triggers>
                    </Style>
                </ListView.ItemContainerStyle>
    
                <ListView.View>
                    <GridView>
                        <GridView.Columns>
                            <GridViewColumn Header="Title" Width="350" DisplayMemberBinding="{Binding Title}"/>
    
                            <GridViewColumn Header="Time" Width="114" 
                                        DisplayMemberBinding="{Binding Time, Converter={StaticResource TimeSpanFormatConverter}}"/>
                        </GridView.Columns>
                    </GridView>
                </ListView.View>
            </ListView>
    
            <DataGrid Grid.Row="1" AutoGenerateColumns="False" ItemsSource="{Binding FilesCollection}" IsReadOnly="True">
                <DataGrid.Columns>
                    <DataGridCheckBoxColumn Binding="{Binding IsPlaying}" Header="IsPlaying" />
                    <DataGridTextColumn Binding="{Binding Title}" Header="Title" />
                    <DataGridTextColumn Binding="{Binding Time}" Header="Time" />
                </DataGrid.Columns>
            </DataGrid>
    
            <Button Content="Toggle File 5 IsPlaying" Grid.Row="2" Margin="10" Click="Button_Click" />
        </Grid>
    </Window>
