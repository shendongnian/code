            UserControl1 uc = new UserControl1();
            uc.DataContext = new MainViewModel();
            Window1 window = new Window1();
            window.Content = uc;
           
            var myView = window.Content as FrameworkElement;
            var vm = aa.DataContext;//vm now has boxed DataContext (object)
            MainViewModel myMainViewModel = (MainViewModel)vm;
            myMainViewModel.Title="My new Title";
    
