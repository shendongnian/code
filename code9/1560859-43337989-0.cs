    public void UpdateProgressBar( int value)
    {
       if(progressBar1.InvokeRequired){
           progressBar1.Invoke(new MethodInvoker(() => progressBar1.Value=value));
       }else{
           progressBar1.Value =value;
       }
    }
