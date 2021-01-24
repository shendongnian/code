        // a constant to avoid magic strings
        const string KEY_FOR_TRY = "TRY";
        ArrayAdapter<string> _spinnerAdapter;
        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            string user;
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences (this);
            // Load the items from pref and fill the spinner
            // if pref is empty just set an empty list.
            // GetStringSet because you are loading the collection you saved.
            var savedItems = prefs.GetStringSet (KEY_FOR_TRY, new List<string> ());
            var items = new List<string> (savedItems);
            Button button4 = FindViewById<Button> (Resource.Id.button4);
            Spinner spinner = FindViewById<Spinner> (Resource.Id.spinner1);
            EditText input = FindViewById<EditText> (Resource.Id.input);
            user = input.Text;
            button4.Click += delegate
                    {
                        //you might want validate for empty strings and if entry is already saved to prevent duplicates.
                        user = input.Text;
                        items.Add (user);
                        ISharedPreferencesEditor editor = prefs.Edit ();
                        //PutStringSet because you are saving a collection.
                        editor.PutStringSet (KEY_FOR_TRY, items);
                        editor.Apply ();
                         //do this only if you want to refresh the spinner values.
                        _spinnerAdapter.Insert (user, 0);
                        _spinnerAdapter.NotifyDataSetChanged ();
                    };
            //Get the first item if there is any, don't know why you need this.
            user = items.FirstOrDefault ();
            _spinnerAdapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleSpinnerItem, items);
            spinner.Adapter = _spinnerAdapter;
        }
    }
