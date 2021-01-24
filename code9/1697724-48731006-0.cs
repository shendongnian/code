    seekBar.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) => {
        if (e.FromUser < oldValue)
        {
            oldValue = e.Progress;
            //your stuff
        }
        seekBar.Progress = oldValue;
    };
