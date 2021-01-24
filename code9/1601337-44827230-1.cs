    private int _ticksPerUpdate = 2;
    private int _numberOfDots = 3;
    
    private void ProcessTimer_Tick(object sender, EventArgs e)
    {
        _ticks++;
        
        if(_ticks == (_ticksPerUpdate * (_numberOfDots + 1)))
        {
            _ticks = 0;
            ProcessLbl.Text = InitialProcessText;
        }        
        else if(_ticks % _ticksPerUpdate == 0)
        {
            ProcessLbl.Text += ".";
        }
    }
