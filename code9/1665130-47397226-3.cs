        public static int Main()
        {
            Thread app = new Thread((ThreadStart)delegate
            {
                MyLoginControl login = new MyLoginControl();
                MyLoginVM lvm = new MyLoginVM();
                login.DataConetxt = lvm;
                login.ShowDialog();
                if (lvm.IsLoginFailed)
                {
                    return;
                }
                else
                {
                   MainWindow myApp = new MainWindow();
                   MyAppVm avm = new MyAppVm();
                   myApp.DataContext = avm;
                   myApp.ShowDialog();
                }
            }
            app.SetApartmentState(ApartmentState.STA);
            app.Start();
            return 0;
        }
