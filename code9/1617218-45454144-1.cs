    ProgressDialog progress = new ProgressDialog(this);
    progress.Indeterminate = true;
    progress.SetProgressStyle(ProgressDialogStyle.Spinner);
    
    progress.SetMessage("Contacting server. Please wait...");
    progress.SetCancelable(true);
    progress.Show();
    
    var task = new MyTask(progress);
    task.Execute();
