    <Window x:Class="WPF.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-commpatibility/2006"
            xmlns:local="clr-namespace:WPFXamDataGrid"
            mc:Ignorable="d"
            Title="MainWindow" Height="350" Width="525" Loaded="Window_Loaded">
        
        <Grid>
            <StackPanel x:Name="Container">
                <CheckBox Content="Do Everything" IsThreeState="True"/>
                <CheckBox Content="Eat" Margin="20,0,0,0"/>
                <CheckBox Content="Pray" Margin="20,0,0,0"/>
                <CheckBox Content="Love" Margin="20,0,0,0"/>
            </StackPanel>
        </Grid>
        
    </Window>
    
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    
    namespace WPF
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                foreach (CheckBox check in FindVisualChildren<CheckBox>(Container))
                {
                    // you can create your cases here
                    // my case is all checkboxes checked
                    check.IsChecked = true;
                }
            }
    
            public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
            {
                if (depObj != null)
                {
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                    {
                        DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                        if (child != null && child is T)
                        {
                            yield return (T) child;
                        }
    
                        foreach (T childOfChild in FindVisualChildren<T>(child))
                        {
                            yield return childOfChild;
                        }
                    }
                }
            }
        }
    }
