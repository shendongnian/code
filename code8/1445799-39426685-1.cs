    if (to.Equals(from)) {
            if (_timer == null)
            {
                _timer = new Timer(x =>
                {
                    //completeCode
                }, null, translate.Time * 1000, Timeout.Infinite);
            }
            else
            {
                _timer.Change(translate.Time * 1000, Timeout.Infinite);
            }
        return;       
    }
