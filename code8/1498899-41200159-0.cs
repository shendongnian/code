      public partial class Form2 : Form
            {
                public Form2()
                {
                    InitializeComponent();
        
                    BackgroundWorker bgw = new BackgroundWorker();
                    bgw.RunWorkerAsync();
                    bgw.DoWork += new DoWorkEventHandler(dowork);
                    bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(completed);
                }
                void dowork(object sender, DoWorkEventArgs e)
                {    
                    e.Result = InitializeNeededDataToShowOnTheSecondform();
                }
        
               
                void completed(object sender, RunWorkerCompletedEventArgs e)
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        var f2 = new Form3(e.Result);
                        f2.ShowDialog();
                        this.Close();
                        
                    }));
                }
        
                private object InitializeNeededDataToShowOnTheSeconDform()
                {
    //time consuming data initialization and/or any other time consuming process
                    return 10;
                }
        
            } 
