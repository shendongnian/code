    public override Dialog OnCreateDialog(Bundle savedInstanceState)
    {
        var view = Activity.LayoutInflater.Inflate(Resource.Layout.dialog_createAccount,null);
        Dialog.Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);
        listResults = view.FindViewById<ListView>(Resource.Id.listResults);
        listAdapter = new MyListViewAdapter(Activity, testResults, Resource.Layout.listview_row);
        listResults.Adapter = listAdapter;
        spinAdapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleSpinnerDropDownItem);
        spinAdapter.Add("Male");
        spinAdapter.Add("Female");
        spin.Adapter = spinAdapter;
        spin.ItemSelected += Spin_ItemSelected;
        AlertDialog.Builder builder = new AlertDialog.Builder(Activity);
        builder.SetView(view);
        return builder.Create();
    }
