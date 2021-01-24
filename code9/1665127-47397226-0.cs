        public static int Main()
        {
            Thread app = new Thread((ThreadStart)delegate
            {
                MyLoginControl login = new MyLoginControl();
                login.ShowDialog();
                if (login.IsFailed)
                {
                    return;
                }
                else
                {
                   MainWindow myApp = new MainWindow();
                   myApp.ShowDialog();
                }
            }
            app.SetApartmentState(ApartmentState.STA);
            app.Start();
            return 0;
        }
