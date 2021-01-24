    private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
    {
        var ex = e.UserState as Exception;
        if(ex!= null)
            ListViewCostumControl.lvnf.Items.Add(ex.Message);
        else
            label2.Text = e.ProgressPercentage.ToString();;
    }
    
    
    void DirSearch(string sDir)
    {
        try
        {
            foreach (string d in Directory.GetDirectories(sDir))
            {
                foreach (string f in Directory.GetFiles(d))
                    backgroundWorker1.ReportProgress(countfiles++);
    
                DirSearch(d);
            }
        }
        catch (System.Exception excpt)
        {
            backgroundWorker1.ReportProgress(countfiles, excpt);
        }
    }
