    using System;
    using System.Windows;
    using System.Windows.Controls;
    using Windows.System.Display;
    namespace SuspendScreenSaverWpf
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private DisplayRequest mDisplayRequest;
            public MainWindow()
            {
                InitializeComponent();
            }
            private void SuspendButton_Click(object sender, RoutedEventArgs e)
            {
                Button b = sender as Button;
                if (b != null)
                {
                    try
                    {
                        if (mDisplayRequest == null)
                        {
                            // This call creates an instance of the displayRequest object
                            mDisplayRequest = new DisplayRequest();
                        }
                    }
                    catch (Exception ex)
                    {
                        this.MessageBoard.Content = $"Error Creating Display Request: {ex.Message}";
                    }
                    if (mDisplayRequest != null)
                    {
                        try
                        {
                            // This call activates a display-required request. If successful,
                            // the screen is guaranteed not to turn off automatically due to user inactivity.
                            mDisplayRequest.RequestActive();
                            this.MessageBoard.Content = $"Display request activated - ScreenSaver suspended";
                            this.EnableButton.IsEnabled = true;
                            this.SuspendButton.IsEnabled = false;
                        }
                        catch (Exception ex)
                        {
                            this.MessageBoard.Content = $"Error: {ex.Message}";
                        }
                    }
                }
            }
            private void EnableButton_Click(object sender, RoutedEventArgs e)
            {
                Button b = sender as Button;
                if (b != null)
                {
                    if (mDisplayRequest != null)
                    {
                        try
                        {
                            // This call de-activates the display-required request. If successful, the screen
                            // might be turned off automatically due to a user inactivity, depending on the
                            // power policy settings of the system. The requestRelease method throws an exception
                            // if it is called before a successful requestActive call on this object.
                            mDisplayRequest.RequestRelease();
                            this.MessageBoard.Content = $"Display request released - ScreenSaver enabled.";
                            this.SuspendButton.IsEnabled = true;
                            this.EnableButton.IsEnabled = false;
                        }
                        catch (Exception ex)
                        {
                            this.MessageBoard.Content = $"Error: {ex.Message}";
                        }
                    }
                }
            }
        }
    }
    <Window x:Class="SuspendScreenSaverWpf.MainWindow"
                        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
                        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                        xmlns:local="clr-namespace:SuspendScreenSaverWpf"
                        mc:Ignorable="d"
                        Title="MainWindow ScreenSaver management demo" Height="350" Width="525">
        <Grid>
            <Button x:Name="SuspendButton" IsEnabled="true" Content="Suspend ScreenSaver" HorizontalAlignment="Left" Margin="73,250,0,0" VerticalAlignment="Top" Width="150" Click="SuspendButton_Click"/>
            <Button x:Name="EnableButton" IsEnabled="False" Content="Enable ScreenSaver" HorizontalAlignment="Left" Margin="298,250,0,0" VerticalAlignment="Top" Width="150" Click="EnableButton_Click"/>
            <Label x:Name="MessageBoard" Content="Example project demonstrating how to disable ScreenSaver on Windows 10" HorizontalAlignment="Left" Height="78" Margin="73,39,0,0" VerticalAlignment="Top"  Width="375"/>
        </Grid>
    </Window>
