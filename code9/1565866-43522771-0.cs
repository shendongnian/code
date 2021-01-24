    private void Form1_Load(object sender, EventArgs e)
    {
        try
        {
            Process edgeProc = Process.Start("microsoft-edge:.exe");
            edgeProc?.Kill(); // the "?." will prevent the NullReferenceException 
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message + Environment.NewLine +    Environment.NewLine + ex.StackTrace);
        }
    }
