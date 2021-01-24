    //As long as its not closed by the system, its closed by the user
    private bool closedByUser = true;
    private void timerClose_Tick(object sender, System.Timers.ElapsedEventArgs e)
    {
        if (this.InvokeRequired)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                //closed by system
                closedByUser = false;
                this.Close();
            });
        }
        else
        {
            this.Close();
        }
    }
    private void DISPLAY_FormClosed(object sender, FormClosedEventArgs e)
    {
        if(closedByUser)
            timerClose.Stop();
            //Closed by user
        else
            timerClose.Stop();
            //Not closed by user
    }
