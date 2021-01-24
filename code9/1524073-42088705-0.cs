        DispatcherTimer dispatcherTimer;
        ... //Copied from question
        int timesToTick = 60; 
       
        public class PageBaseWithTimer: PhoneApplicationPage
        {
            PageBase()
            {
                this.Loaded += PageBase_Loaded;
                this.OnManipulationCompleted += PhoneApplicationPage_ManipulationCompleted
            }
    
            private void PageBase_Loaded(object sender, RoutedEventArgs e)
            {
                 dispatcherTimer = new DispatcherTimer();
                 ... //Copied from question
                 dispatcherTimer.Start();
            }
    
            private void PhoneApplicationPage_ManipulationCompleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
            {
                startTime = DateTimeOffset.Now;
                lastTime = startTime;
                dispatcherTimer.Start();  
            }      
            void dispatcherTimer_Tick(object sender, object e)
            {
                DateTimeOffset time = DateTimeOffset.Now;
           
                ... //Copied from question
                MessageBox.Show("Login again", "Session Expired", MessageBoxButton.OK);
                NavigationService.Navigate(new Uri("/Login_3.xaml", UriKind.Relative)); 
            }
            protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs args)
            {
                //dispose timer
                dispatcherTimer.Stop();
                dispatcherTime.Tick -= dispatcherTimer_Tick
                dispatcherTimer = null;
            }
