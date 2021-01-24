    public MainWindow()
            {
                InitializeComponent();
    
                //hovering start
                KinectRegion.SetKinectRegion(this, kinectRegion);
    
                App app = ((App)Application.Current);
                app.KinectRegion = kinectRegion;
    
                // Use the default sensor
                this.kinectRegion.KinectSensor = KinectSensor.GetDefault();
                //hovering end
            }
