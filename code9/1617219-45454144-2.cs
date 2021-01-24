    private class MyTask : AsyncTask
    {
        private ProgressDialog progress;
        private Context context;
    
        public MyTask(Context mcontext)
        {
            context = mcontext;
        }
    
        protected override void OnPreExecute()
        {
            base.OnPreExecute();
            progress = new ProgressDialog(context);
            progress.Indeterminate = true;
            progress.SetProgressStyle(ProgressDialogStyle.Spinner);
    
            progress.SetMessage("Contacting server. Please wait...");
            progress.SetCancelable(true);
            progress.Show();
        }
    
        protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
        {
            //do your work here and return the result
            PublishProgress(10);
            return null;
        }
    
        protected override void OnProgressUpdate(params Java.Lang.Object[] values)
        {
            base.OnProgressUpdate(values);
            Task.Delay(2000).ContinueWith(t =>
            {
                progress.SetMessage("Checking account info...");
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    
        protected override void OnPostExecute(Java.Lang.Object result)
        {
            base.OnPostExecute(result);
            Task.Delay(5000).ContinueWith(t =>
            {
                progress.Dismiss();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
