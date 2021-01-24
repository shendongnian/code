    public class DBInflaterAsyncTask : AsyncTask
    {
        protected override Object DoInBackground(params Object[] @params)
        {
            // You can not on the UI thread
            Task.Delay(1000); // create db
            PublishProgress(new Object[] { 33 });
            Task.Delay(1000); // create tables
            PublishProgress(new Object[] { 66 });
            Task.Delay(1000); // create load data
            PublishProgress(new Object[] { 99 });
            return null;
        }
        protected override void OnProgressUpdate(params Object[] values)
        {
            // You are on the UI thread
            Log.Debug("SomeTag", values[0].ToString());
        }
    }
