    public void UpdateProgress(int percentComplete)
    {
       if (!InvokeRequired)
       {
          ProgressBar.Value = percentComplete;
       }
       else
       {
          Invoke(new Action<int>(UpdateProgress), percentComplete);
       }
    }
