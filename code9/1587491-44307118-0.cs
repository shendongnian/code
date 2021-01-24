    [Activity (Label = "MyView")]			
    public class MyView : MvxActivity
    {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);
            SetContentView(Resource.Layout.ThirdNativeView);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
        }
        /// handle back navigation here
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
        	switch (item.ItemId)
        	{
        		case Android.Resource.Id.Home:
        			//Execute viewModel command here
        			this.Finish();
        			return true;
        		default:
        			return base.OnOptionsItemSelected(item);
        	}
        }
    }
