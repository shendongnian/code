    public class retrievePosts : AsyncTask<string, string, List<AwarePosts>>
    {
        List<AwarePosts> awr;
        Context mContext;
        RecyclerAdapter mAdapter
        public retrievePosts(Context context, RecyclerAdapter adapter)
        {
            mContext = context;
            mAdapter = adapter;
        }
    
        protected override void OnPreExecute()
        {
            AndroidHUD.AndHUD.Shared.ShowImage(mContext, Resource.Drawable.load2, "Getting Posts...");
        }
    
        protected override List<AwarePosts> RunInBackground(params string[] @params)
        {
            List<string> img = aw.drawableImageToBase64String(mContext); 
            //not sure what are you doing here, if you want to get some objects from your awarenessActivity, still try to make it as a parameter and pass to here.
            return awr;
        }
    
        protected override void OnPostExecute(List<AwarePosts> result)// this function is supposed to run on the UI thread
        {
            base.OnPostExecute(result);
            mAdapter = new RecyclerAdapter(result); // assigning the data here
            mAdapter.NotifyDataSetChanged();//y'all kn what i'm trying to do here
            AndroidHUD.AndHUD.Shared.Dismiss(mContext);
            Toast.MakeText(mContext, "successful", ToastLength.Long).Show();
        }
    }
