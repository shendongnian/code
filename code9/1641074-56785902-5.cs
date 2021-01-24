    <Window x:Class="WPFTestControlMoveMouse.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:WPFTestControlMoveMouse"
            mc:Ignorable="d"
            Title="MainWindow" Height="450" Width="800">
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="30" />
                <RowDefinition />
            </Grid.RowDefinitions>
            <Button Grid.Row="0" Click="Button_Click">New</Button>
            <Canvas x:Name="MyCanvas" Grid.Row="1"></Canvas>
        </Grid>
    </Window>
---
    using System;
    using System.Collections.Generic;
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
    namespace WPFTestControlMoveMouse
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
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                MyCanvas.Children.Add(new VisualBlock());
            }
        }
    }
