        public MainWindow() {
            InitializeComponent();
            Initialize(); //do some intialization
        }
        private async void Timer_Tick(object sender, EventArgs e) {
            if (DateTime.Now >= timePicker.SelectedDate) { //check your condition
                timer.Stop(); //probably you need to run it just once
                await Task.Run(() => OtherMethod()); //instead of creating thread manually use Thread from ThreadPool
                //use async method to avoid blocking UI during long method is running
            }
        }
        private readonly DispatcherTimer timer = new DispatcherTimer(); //create a dispatcher timer that will execute code on UI thread
        public void Initialize() {
            MytextBlock.Text = "new text";
            MyOtherTextBlock.Text = "Hello"; //access UI elements normally
            for (var i = 0; i < 50; i++) {
                Debug.WriteLine("Debug line " + i);
            }
            if (MyRadioButton.IsChecked == false)
            {
                timer.Interval = TimeSpan.FromSeconds(10); // during init setup timer instead of while loop
                timer.IsEnabled = true;
                timer.Tick += Timer_Tick; //when 10 sec pass, this method is called
                timer.Start();
            }
        }
        public void OtherMethod() {
            //long running method
            Thread.Sleep(1000);
        }
