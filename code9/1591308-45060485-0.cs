    var vstoPresentation = Globals.ThisAddIn.Application.ActivePresentation;
    //declare a variable to check if video is uploading
    public bool videoUploading = false;
    //we need to register a "BeforeClose" handler 
    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        this.Application.PresentationBeforeClose += new EApplication_PresentationBeforeCloseEventHandler(Application_PowerPointBeforeClose);
    }
    internal void upload(){
        vstoPresentation.CreateVideo("path\\to\\filename.mp4");
        // Set cursor as hourglass
        Cursor.Current = Cursors.WaitCursor;
        System.Timers.Timer aTimer = new System.Timers.Timer();
        aTimer.Elapsed += new ElapsedEventHandler((s, e) => {
            if (Globals.ThisAddIn.vstoPresentation.CreateVideoStatus == PowerPoint.PpMediaTaskStatus.ppMediaTaskStatusDone)
            {
                Globals.ThisAddIn.videoUploading = true;
                // Executing my time-intensive hashing code here...
                // uploading video to server
                // when upload finished
                // Set cursor as default arrow
                Cursor.Current = Cursors.Default;
                Globals.ThisAddIn.videoUploading = false;
            }
        });
        aTimer.Interval = 5000;
        aTimer.Enabled = true;
    }
    private void Application_PowerPointBeforeClose(Presentation Pres, ref bool Cancel)
    {
        if (Globals.ThisAddIn.videoUploading == true)
        {
            DialogResult dialogResult = MessageBox.Show("Video upload is in progress, are you sure you want to abort?", "My Addin", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.No)
            {
                Cancel = true;
            }
        }
    }
