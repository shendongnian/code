    var t = new System.Timers.Timer();
    t.Interval = 250;   // In miliseconds
    t.Elapsed += (sender, args) =>
    {
        // Change color back on the UI-Thread
        RunOnUiThread(() =>
        {
            e.View.SetBackgroundColor(Color.Orange);        
        });
        
    };
    t.Start();
