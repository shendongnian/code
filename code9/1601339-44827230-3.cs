    private readonly int _ticksPerUpdate = 2;
    private readonly int _maxNumberOfDots = 3;
    
    private void ProcessTimer_Tick(object sender, EventArgs e)
    {
        _ticks++;
        
        if(_ticks == (_ticksPerUpdate * (_maxNumberOfDots + 1)))
        {
            _ticks = 0;
            ProcessLbl.Text = InitialProcessText;
        }        
        else if(_ticks % _ticksPerUpdate == 0)
        {
            ProcessLbl.Text += ".";
        }
    }
