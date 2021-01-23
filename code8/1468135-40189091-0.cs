    // TextForThisWindow is a global variable declared in this class.
    ...
    void firstCommandExecute()
        {
            TextForThisWindow = "Text";
            System.Windows.Application.Current.MainWindow.Hide();
            secondWindow sw = new secondWindow(Text);
            sw .WindowStartupLocation = WindowStartupLocation.CenterScreen;
            sw .Show();
        }
        bool CanfirstCommandExecute()
        {
            return true;
        }
        public ICommand firstCommand{ get { return new RelayCommand(firstCommandExecute, CanfirstCommandExecute); } }
        void secondCommandExecute()
        {
            Info = "info";
            
            if (TextForThisWindow.Contains("X"))
            {
                Selected = "X";
            }
            PathOfSelectedInfo = img.getPathOfSelectedInfo(ImagePathM1, Info);
            path = PathOfSelectedInfo;
            thirdWindow tw= new thirdWindow("Text" + Selected);
           tw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
           tw.Show();
        }
        
        CanthirdWindowExecute()
        {
            return true;
        }
        public ICommand secondCommand{ get { return new RelayCommand(secondCommandExecute, CansecondCommandbExecute); } }
