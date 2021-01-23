    public MainForm()
        {
            InitializeComponent();
            FormWithLabel splash = new FormWithLabel();
            //start long-term work in a separate thread
            new Task(() => { DoHeavyWork(splash); }).Start();
            //FormWithLabel will be closed at the end of DoHeavyWork task
            splash.ShowDialog(this);
        }
    private void DoHeavyWork(FormWthLabel splash)
        {
            for (int i = 1; i <= 5; i++)
            {
                //checking whether FormWithHelp handle is already created to ensure 
                //that following Invoke will not throw InvalidOperationException
                while (!lScreen.IsHandleCreated)
                    Thread.Sleep(50);
                //changing text inside a label on FormWithLabel (assuming label is public)
                splash.Invoke(new Action(() => { splash.label.Text = "Loading item №" + i; }));   
                //some heavy work emulation
                Thread.Sleep(1000);                             
            }
            //closing FormWithLabel and continuing main thread (showing fully filled main form)
            splash.Invoke(new Action(splash.Close));
        }
