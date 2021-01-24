    private void StartBtn_Click(object sender, EventArgs e)
    {
        if(fileName != "No file selected")
        {
            ValidationLbl.Text = null;
            ProcessLbl.Text = "Application is now running.";
            InitialProcessText = ProcessLbl.Text;
            
            // reset the variable
            _ticks = 0
            ProcessTimer.Start();
        }
        else
        {
            ValidationLbl.Text = "No file was added";
        }
    }
