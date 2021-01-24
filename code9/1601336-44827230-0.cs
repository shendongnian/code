    private void ProcessTimer_Tick(object sender, EventArgs e)
    {
        _ticks++;
        
        if(_ticks == 8)
        {
            _ticks = 0;
            ProcessLbl.Text = InitialProcessText;
        }        
        else if(_ticks % 2 == 0)
        {
            ProcessLbl.Text += ".";
        }
    }
