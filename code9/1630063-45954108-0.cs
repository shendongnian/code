            var thread = new Thread(() =>
            {
                fk = new FullKeyboard();
                fk.Show();
                App.Current.Dispatcher.ShutdownStarted += Dispatcher_ShutdownStarted;
                System.Windows.Threading.Dispatcher.Run();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
