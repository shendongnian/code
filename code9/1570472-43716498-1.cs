    public class MainActivity : Activity
    {
        Spinner mSpinner;
        bool validatePass=false;
        TextView tvResult;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            mSpinner = FindViewById<Spinner>(Resource.Id.mSpinner);
            var list = InitList();
            SpinnerAdapter adapter = new SpinnerAdapter(this, list);
            tvResult = FindViewById<TextView>(Resource.Id.tvResult);
            mSpinner.Adapter = adapter;
            mSpinner.ItemSelected += MSpinner_ItemSelected;
        }
        private void MSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            //use validatePass to indicate if user has selected something.
            if (e.Position != 0)
            {
                validatePass = true;
            }
            else
            {
                validatePass = false;
            }
            tvResult.Text ="Validate Result: "+ validatePass.ToString();
        }
        private List<string> InitList()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 15; i++)
            {
                list.Add("Item: " + i);
            }
            return list;
        }
    }
