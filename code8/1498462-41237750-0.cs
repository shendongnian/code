    public class MainActivity : Activity
    {
        EditText et;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            et = (EditText)FindViewById(Resource.Id.edittext);
            et.Click += Et_Click; 
        }
      
        private void Et_Click(object sender, System.EventArgs e)
        {
            et.Hint = "";
        }
    }
