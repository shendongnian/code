    <Window x:Class="WpfApplication9.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:WpfApplication9"
            mc:Ignorable="d"
            Title="MainWindow" Height="350" Width="525"
            PreviewMouseDown="Window_PreviewMouseDown"
            >
        <Grid>
            <Button x:Name="button1" Content="sampleButton" Click="Button_Click" Width="100" Height="100"/>
        </Grid>
    </Window>
    
    
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace WpfApplication9
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
    
            private void Button_Click(Object sender, RoutedEventArgs e)
            {
                Debug.WriteLine("button is after preview!");
            }
    
            private void Window_PreviewMouseDown(Object sender, MouseButtonEventArgs e)
            {
                Debug.WriteLine("preview down");
    
                // could loop thorugh all the UI elements and check IsMouseOver ?  <---- might be a better method. 
                if(button1.IsMouseOver)
                {
                    Debug.WriteLine("button about to be clicked");
                }
    
                e.Handled = false; 
            }
        }
    }
