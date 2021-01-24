        private ICommand _btnMainAdminPage;
        public ICommand BtnMainAdminPageGO
        {
            get
            {
                if (_btnMainAdminPage == null)
                {
                    _btnMainAdminPage = new RelayCommand(param => this.BtnMainAdminPage(), null);
                }
                return _btnMainAdminPage;
            }
        }
        private void BtnMainAdminPage()
        {
            WindowMainAdmin dashboard = new WindowMainAdmin();
            dashboard.Show();
            foreach(Window window in Application.Current.Windows)
            {
                if (window is WindowOPHome)
                {
                    window.Close();
                    break;
                }
            }
            
        }
