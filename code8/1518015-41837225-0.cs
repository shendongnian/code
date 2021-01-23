    private readonly ProgressBar[] _bars = 
        new[]
        {
            vProgressBar0, vProgressBar1, vProgressBar2, vProgressBar3
        };
    public void StartProgress()
    {
        for (int i = 0; i < _bars.Length; ++ i)
        {
            var progressBar = _bars[i]; // If "i == 0" this is the "vProgressBar0" instance.
            // Use it here...
        }
    }
