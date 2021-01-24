    using System;
    using System.Windows;
    using System.IO.Pipes;
    using System.Threading;
    using System.Windows.Threading;
    namespace InterprocessCommunicationViaPipes
    {
        /// <summary>
        ///   Commands used to communiate via pipe 
        /// </summary>
        public enum EPipeCommands : byte
        {
            None, Show, Hide, Close
        };
        /// <summary>
        ///   Interaction logic for MainWindow.xaml 
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                Title = DateTime.UtcNow.ToString("o");
            }
            /// <summary>
            ///   Name of the pipe used for interprocess communication 
            /// </summary>
            private const string PipeName = "MyCoolApp";
            /// <summary>
            ///   prevents double Close() calls 
            /// </summary>
            private bool isClosing = false;
            /// <summary>
            ///   Server 
            /// </summary>
            private NamedPipeServerStream pipeServerStream = null;
            /// <summary>
            ///   Thread server is running in 
            /// </summary>
            private Thread ServerThread;
            void ActOnPipeCommand(EPipeCommands c)
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, 
                    new ThreadStart(
                    delegate
                    {
                        tb.Text += $"\n{DateTime.UtcNow:o} recieved {c}\n";
                        switch (c)
                        {
                            case EPipeCommands.None:
                                return;
                            case EPipeCommands.Hide:
                                Hide();
                                break;
                            case EPipeCommands.Show:
                                if (this.WindowState == WindowState.Minimized)
                                    WindowState = WindowState.Normal;
                                Visibility = Visibility.Visible;
                                break;
                            case EPipeCommands.Close when !isClosing:
                                Close();
                                break;
                            case EPipeCommands.Close:
                                tb.Text += $"Already closing.\n";
                                break;
                            default:
                                tb.Text += $"Unmapped pipe action: {c.ToString()}\n";
                                break;
                        }
                    }));
            }
            /// <summary>
            ///   Server running? 
            /// </summary>
            /// <returns></returns>
            bool CheckIsRunning()
            {
                NamedPipeClientStream clientStream = new NamedPipeClientStream(PipeName);
                try
                {
                    clientStream.Connect(1000);
                }
                catch (TimeoutException)
                {
                    tb.Text = $"No Server found.";
                    return false;
                }
                clientStream.WriteByte((byte)EPipeCommands.Show);
                return true;
            }
            EPipeCommands InterpretePipeCommand(int v)
            {
                if (Enum.TryParse<EPipeCommands>($"{v}", out var cmd))
                    return cmd;
                return EPipeCommands.None;
            }
            /// <summary> Creates the server, listens to connectiontrys, 
            /// reads 1 byte & disconnects </summary> 
            /// <param name="data"></param>
            void PipeServer(object data)
            {
                pipeServerStream = new NamedPipeServerStream(
                    PipeName, PipeDirection.InOut, 
                    2, PipeTransmissionMode.Byte);
                do
                {
                    pipeServerStream.WaitForConnection();
                    if (pipeServerStream.IsConnected && !isClosing)
                    {
                        ActOnPipeCommand(
                            InterpretePipeCommand(
                                pipeServerStream.ReadByte()));
                    }
                    pipeServerStream.Disconnect();
                }
                while (!isClosing);
            }
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                if (CheckIsRunning())
                    Close();
                else
                {
                    ServerThread = new Thread(PipeServer);
                    ServerThread.Start();
                    tb.Text = "Starting new pipe server.\n";
                    Closing += (a, b) => isClosing = true;
                }
            }
        }
    }
