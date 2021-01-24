    if (IsPosixEnvironment)
    {
        _linTimer = new PosixHiPrecTimer();
        _linTimer.Tick += LinTimerElapsed;
        _linTimer.Interval = _stepsize;
        _linTimer.Enabled = true;
    }
    else
    {
        _winTimer = new WinHiPrecTimer();
        _winTimer.Elapsed += WinTimerElapsed;
        _winTimer.Interval = _stepsize;
        _winTimer.Resolution = 25;
        _winTimer.Start();
    }
