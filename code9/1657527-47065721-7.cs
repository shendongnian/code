    <Window x:Class="ManageScreenSaver.MediaElementWpf.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:ManageScreenSaver.MediaElementWpf"
            mc:Ignorable="d"
            Title="MainWindow" Height="570" Width="550" MinHeight="570" MinWidth="550" MaxHeight="570" MaxWidth="550">
        <Grid Margin="0,0,0,0">
            <MediaElement x:Name="myMediaElement" Width="530" Height="270" LoadedBehavior="Manual" HorizontalAlignment="Center"  VerticalAlignment="Center" IsMuted="True" Stretch="Fill" Margin="10,52,10,197" >
                <MediaElement.Triggers>
                    <EventTrigger RoutedEvent="MediaElement.Loaded">
                        <EventTrigger.Actions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <MediaTimeline Source="..\..\BigBuckBunny_320x180.mp4" Storyboard.TargetName="myMediaElement" RepeatBehavior="Forever" />
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger.Actions>
                    </EventTrigger>
                </MediaElement.Triggers>
            </MediaElement>
            <Button x:Name="SuspendButton" IsEnabled="true" Content="Suspend ScreenSaver" HorizontalAlignment="Left" Margin="74,489,0,0" VerticalAlignment="Top" Width="150" Click="SuspendButton_Click" RenderTransformOrigin="0.501,2.334"/>
            <Button x:Name="EnableButton" IsEnabled="true" Content="Enable ScreenSaver" HorizontalAlignment="Left" Margin="302,489,0,0" VerticalAlignment="Top" Width="150" Click="EnableButton_Click" RenderTransformOrigin="0.508,1.359"/>
            <Label x:Name="MessageBoard" Content="Example project demonstrating how to disable ScreenSaver on Windows 10" HorizontalAlignment="Left" Height="25" Margin="44,10,0,0" VerticalAlignment="Top"  Width="432"/>
            <TextBox x:Name="TextBox" Text="" HorizontalAlignment="Center" HorizontalContentAlignment="Left" Height="110" Margin="10,342,10,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="510"/>
        </Grid>
    </Window>
    using System;
    using System.Timers;
    using System.Windows;
    using System.Windows.Controls;
    using Windows.System.Display;
    namespace ManageScreenSaver.MediaElementWpf
    {
        public partial class MainWindow : Window
        {
            private DisplayRequest mDisplayRequest;
            internal static TextBoxWriter Console;
            private static ScreenSaverManager _ScreenSaverManager;
            public MainWindow()
            {
                InitializeComponent();
                Console = new TextBoxWriter(this.TextBox);
                _ScreenSaverManager = ScreenSaverManager.Instance;
                PrintSSaverStatus(" MainWindow.ctor");
            }
            private void PrintSSaverStatus(string apendedText = "")
            {
                Console.WriteLine(GetScreenSaverStatusMessage() + apendedText);
            }
            private void SuspendButton_Click(object sender, RoutedEventArgs e)
            {
                Button b = sender as Button;
                if (b != null)
                {
                    EnsureDisplayRequest();
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
                        PrintSSaverStatus(" SuspendButton_Click");
                    }
                }
            }
            private void EnsureDisplayRequest()
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
            }
            private void EnableButton_Click(object sender, RoutedEventArgs e)
            {
                Button b = sender as Button;
                if (b != null)
                {
                    EnsureDisplayRequest();
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
                        PrintSSaverStatus(" EnableButton_Click");
                    }
                }
            }
            private string GetScreenSaverStatusMessage()
            {
                string message = $"Screen Saver is: \"{{0}}\", \"{{1}}\", timeout: \"{{2}}\"  {DateTime.UtcNow}";
                message = String.Format(message,
                    NativeMethods.IsScreenSaverActive ? "active" : "inactive",
                    NativeMethods.IsScreenSaverSecure ? "secure" : "not secure",
                    NativeMethods.ScreenSaverTimeout);
                return message;
            }
        }
    }
