    protected override void OnCreate(Bundle savedInstanceState)
    {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Database);
            
            ...
            spinnerCategory = FindViewById<Spinner>(Resource.Id.spinnerCategory);
            
            FirebaseApp.InitializeApp(this);
            reference = FirebaseDatabase.Instance.Reference;
            database = FirebaseDatabase.Instance;
            if (reference != null)
            {
                //add value event listener to categories of your database.
                reference.Child("categories").AddValueEventListener(this);
            }
    }
    public void OnDataChange(DataSnapshot snapshot)
    {
            List<string> categories=RetrieveCategories(snapshot);
            UpdateSpinner(categories);
    }
    private List<string> RetrieveCategories(DataSnapshot snapshot)
    {
        List<string> categories = new List<string>();
        var children=snapshot.Children.ToEnumerable<DataSnapshot>();
        HashMap map;
        foreach (var s in children)
        {
            map = (HashMap)s.Value;
            if (map.ContainsKey("categoryName"))
            {
                categories.Add(map.Get("categoryName").ToString());
            }
        }
        return categories;
    }
