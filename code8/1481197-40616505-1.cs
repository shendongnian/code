    private void MyForm : Form
    {
       private CancellationToken ct = new CancellationTokenSource();    
       public MyForm()
       {
          InitializeComponent();
          
          checkbox1.Enable = false;
          //Disable all checkboxes here.
    
          ct = new CancellationTokenSource();
       }
    
       //Event if someone click your start button
       private void buttonStart_Click(object sender, EventArgs e)
       {
          //Enable all checkboxes here
          //This will be called if we get some progress from tcp
          var progress = new Progress<string>(value =>
          {
              //check the behaviour of the checkboxes and write to file
              file.WriteLine(value + behavior);           
          });
          Task.Factory.StartNew(() => ListenToTcp(ct, progress as IProgress<string)); //starts the tcp listening async
       }
    
       //Event if someone click your stop button
       private void buttonStop_Click(object sender, EventArgs e)
       {
          ct.Cancel();
          //Disable all checkboxes (better make a method for this :D)
       }
    
       private void ListenToTcp(CancellationToken ct, IProgess<string> progress)
       {
           do
           {
              if (ct.IsCancellationRequested)
                return;
         
              int temp = data_feed.ReadByte(); //replaced var => temp because var is keyword
              if (temp != -1)
              {
                data_in += (char)temp;
                if (data_in.IndexOf("\r\n") != -1)
                {
                   if (progress != null)
                     progress.Report(data_in); //Report the tcp-data to form thread
                   data_in = "";                 
                }
            }
            while (exit_state == false);
       }
    }
