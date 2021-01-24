                    Thread t = new Thread(() =>
                {                    
                    MainWindow _mainWindow = new MainWindow(GetDistributorsData);
                    _mainWindow.Show();
                    System.Windows.Threading.Dispatcher.Run();
                });
                t.SetApartmentState(ApartmentState.STA);
                t.IsBackground = true;
                t.Start();
