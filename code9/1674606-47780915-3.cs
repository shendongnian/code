    public Form1()
    {
        AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
        {
            string resourceName = new AssemblyName(args.Name).Name + ".dll";
            string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));
    
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
            {
                Byte[] assemblyData = new Byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        };
        InitializeComponent(); 
        backgroundWorker1.WorkerReportsProgress = true;  
        backgroundWorker1.WorkerSupportsCancellation = true;
    }
    private void btnQuery_Click(object sender, EventArgs e)
    {
        backgroundWorker1.RunWorkerAsync();
    }
    
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
    
            //Iterating the array
            foreach (string s in sxc)
            {
                txt_ProgressDetails.Visible = true;
                AppendTextBoxLine("Getting Data For " + s);
    
                //Put data into DataTable
                PopulateDT(s);
            }
    
            //If the cancel button was pressed
            if (backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
    }
    
    delegate void UpdateUICallback(string statusMessage);
    private void AppendTextBoxLine(string statusMessage)
    {
    	if (InvokeRequired)
    	{
    		UpdateUICallback d = new UpdateUICallback(AppendTextBoxLine);
    		this.Invoke(d, new object[] {statusMessage});
    	}
    	else
    	{
    		if (txt_ProgressDetails.Text.Length > 0)
    				txt_ProgressDetails.AppendText(Environment.NewLine);
    		txt_ProgressDetails.AppendText(statusMessage);
    	}
    }
