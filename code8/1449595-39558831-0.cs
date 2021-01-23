    public sealed partial class dna_analyze_page : Page
    {
        Analyzer analyzer;
        DispatcherTimer dispatcherTimer = null; //My dispatcher timer to update UI
        TimeSpan updatUITime = TimeSpan.FromMilliseconds(60); //I update UI every 60 milliseconds
        DataModel myDataModel = new DataModel(); //Your custom class to handle data (The class must be thread safe)
    
        public dna_analyze_page(){
            this.InitializeComponent();
            dispatcherTimer = new DispatcherTimer(); //Initilialize the dispatcher
            dispatcherTimer.Interval = updatUITime;
            dispatcherTimer.Tick += DispatcherTimer_Tick; //Update UI
        }
    
       protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.dispatcherTimer.Start(); //Start dispatcher
        }
       protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            this.dispatcherTimer.Stop(); //Stop dispatcher
        }
       private void DispatcherTimer_Tick(object sender, object e)
        {
           //Update the UI
           myDataModel.getProgress()//Get progess data and update the progressbar
    //etc...
 
         }
    
        private void button_click(object sender, RoutedEventArgs e)
        {
            analyzer = new Analyzer();
    
            analyzer.ReportProgress += new EventHandler<double>(OnUpdateProgress);
            analyzer.ReportCurrent += new EventHandler<string>(OnUpdateCurrent);
            analyzer.ReportObject += new EventHandler<object>(OnUpdateObject);
    
            analyzer.Start();
    
        }
    
        private async void OnUpdateProgress(object sender, double d)
        {
            //update value of UI element progressbar and a textblock ('label')
            //Commenting out all the content the eventhandlers solves the UI 
            //freezing problem
            myDataModel.updateProgress(d); //Update the progress data
        }
    
        private async void OnUpdateCurrent(object sender, string s)
        {
            //update value of UI element textblock.text = s
            myDataModel.updateText(s); //Update the text data
        }
    
        private async void OnUpdateObject(object sender, object o)
        {
            //Add object to a list list that is bound to a listview
            myDataModel.updateList(o); //Update the list data
        }
    }
