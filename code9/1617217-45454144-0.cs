    private class MyTask : AsyncTask
    {
        private ProgressDialog dialog;
    
        public MyTask(ProgressDialog pdialog)
        {
            dialog = pdialog;
        }
    
        protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
        {
            //do your work here and return the result
            dialog.SetMessage("Checking account info...");
            return null;
        }
    
        protected override void OnPostExecute(Java.Lang.Object result)
        {
            base.OnPostExecute(result);
            Task.Delay(3000).ContinueWith(t =>
            {
                dialog.Dismiss();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
