    <Window
        x:Class="Sandbox.Test"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:local="clr-namespace:Sandbox"
        xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        Title="Test"
        mc:Ignorable="d">
        <Window.Resources>
            <ResourceDictionary>
                <ResourceDictionary.MergedDictionaries>
                    <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ProgressBar.xaml" />
                    <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Button.xaml" />
                    <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.CheckBox.xaml" />
                    <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ListBox.xaml" />
                    <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.PopupBox.xaml" />
                    <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.RadioButton.xaml" />
                    <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.TextBlock.xaml" />
                    <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ToggleButton.xaml" />
                </ResourceDictionary.MergedDictionaries>
            </ResourceDictionary>
    
        </Window.Resources>
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="*" />
                <RowDefinition Height="Auto" />
            </Grid.RowDefinitions>
            <ScrollViewer VerticalScrollBarVisibility="Auto" Grid.Row="0">
                <ItemsControl
                    MaxWidth="300"
                    Margin="16,8"
                    ItemsSource="{Binding LongTasks}">
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <ContentControl Content="{Binding}">
                                <ContentControl.Style>
    
                                    <Style TargetType="{x:Type ContentControl}">
                                        <Style.Triggers>
                                            <DataTrigger Binding="{Binding IsFinished}" Value="False">
                                                <DataTrigger.Setters>
                                                    <Setter Property="ContentTemplate">
                                                        <Setter.Value>
                                                            <DataTemplate>
                                                                <DockPanel Margin="12">
                                                                    <ProgressBar
                                                                        HorizontalAlignment="Center"
                                                                        VerticalAlignment="Center"
                                                                        DockPanel.Dock="Right"
                                                                        Style="{StaticResource MaterialDesignCircularProgressBar}"
                                                                        Value="{Binding Progress}" />
                                                                    <TextBlock
                                                                        VerticalAlignment="Center"
                                                                        Style="{StaticResource MaterialDesignDisplay1TextBlock}"
                                                                        Text="Task running" />
                                                                </DockPanel>
                                                            </DataTemplate>
    
                                                        </Setter.Value>
                                                    </Setter>
                                                </DataTrigger.Setters>
                                            </DataTrigger>
                                        </Style.Triggers>
                                        <Setter Property="ContentTemplate">
                                            <Setter.Value>
                                                <DataTemplate>
                                                    <TextBlock
                                                        Margin="12"
                                                        VerticalAlignment="Center"
                                                        Style="{StaticResource MaterialDesignDisplay1TextBlock}"
                                                        Text="Task finished" />
                                                </DataTemplate>
                                            </Setter.Value>
                                        </Setter>
                                    </Style>
                                </ContentControl.Style>
                            </ContentControl>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
    
                </ItemsControl>
            </ScrollViewer>
            <Button
                Grid.Row="1"
                Margin="12"
                HorizontalAlignment="Right"
                Command="{Binding AddLongTask}"
                Content="{materialDesign:PackIcon Kind=Plus,
                                                  Size=32}"
                Style="{StaticResource MaterialDesignFloatingActionButton}" />
        </Grid>
    </Window>
Key point here you seem to want is to use a `DataTrigger` to change a `ContentControl`'s `ContentTemplate` based on your condition so you can display something completely different.
The ViewModel to emulate the long run tasks in background :
