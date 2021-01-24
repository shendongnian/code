    public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        // you don't need this you can safely remove it.
        //var ignored = base.OnCreateView (inflater, container, savedInstanceState);
        // changed this line to properly inflate the fragment's layout 
        var view = inflater.Inflate (Resource.Layout.fragment2_layout, container, false);
        ImageButton scanBtn = view.FindViewById<ImageButton> (Resource.Id. btnScan);
        TextView results = view.FindViewById<TextView> (Resource.Id. Results);
        scanBtn.Click += async (sender, e) => {
            // you don not create a new instance of the Android Application 
           // but get the one already created. From an activity you 
          // just call `Application` but from inside a fragment you need to get 
          // the fragment's activity then get the Application.
            MobileBarcodeScanner.Initialize (Activity.Application);
            var scanner = new MobileBarcodeScanner ();
            var result = await scanner.Scan ();
            // The if was inverted.
            if (result == null)
            {
                return;
            }
            Console.WriteLine ($"Scanned Barcode: {result}");
            // Using this you are sure it will run in the UI thread
            // as you will be updating an UI element.
            Activity.RunOnUiThread (() => {
                results.Text = result.Text;
            });
        };
        return view;
    }
