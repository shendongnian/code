    System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke(new Action(() =>
                {
                    string line = proc.StandardOutput.ReadLine();
                    AddTextToTextbox(line);
                }), null);
