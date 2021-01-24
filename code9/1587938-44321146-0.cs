    <Window x:Class="WpfApp3.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:WpfApp3"
            mc:Ignorable="d"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <TextBlock Name="lblTime"  FontSize="50" Margin="149,50,-149.333,-50.333" />
    
            <Button x:Name="start" Content="Start" HorizontalAlignment="Left" VerticalAlignment="Top" Width="213" Margin="149,166,0,0" Height="50" Click="start_Click"/>
    
        </Grid>
    
    </Window>
    using System;
    using System.Timers;
    using System.Windows;
    
    namespace WpfApp3
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            Timer timer;
            TimeSpan time;
            public MainWindow()
            {
                InitializeComponent();
                time = new TimeSpan(0);
                timer = new Timer();
                timer.Interval = 100;
                timer.Elapsed += timer_Elapsed;
            }
    
            private void timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                time += new TimeSpan(0, 0, 0, 0, 100);
                this.Dispatcher.Invoke(() => {
                    lblTime.Text = time.ToString(@"hh\:mm\:ss\:ff");
                });
                
            }
    
            private void start_Click(object sender, RoutedEventArgs e)
            {
                if (!timer.Enabled)
                {
                    timer.Start();
                    start.Content = "Stop"; 
                }
                else
                {
                    timer.Stop();
                    start.Content = "Start";
                }
            }
        }
    }
