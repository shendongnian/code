    [Activity(Label = "CancelActivity")]
    public class CancelActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.cancel);
    
            this.FindViewById(Resource.Id.cancelButtonYes).Click += delegate
            {
                var password = this.FindViewById(Resource.Id.cancelPassword);
    
                // call KillAlert method from GeneralServic
              GeneralService.generalService.KillAlert(password.TEXT);
    
            };
        }
    }
