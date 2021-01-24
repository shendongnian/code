    lst.ItemClick += (object sender, Android.Widget.AdapterView.ItemClickEventArgs e) =>
    {
        var selectedFromList = (lst.Adapter as ListViewAdapter)[e.Position];
        if(selectedFromList is MenuHeaderItem)
        {
            var intent = new Intent(this, typeof(YOUR_ACTIVITY1));
            StartActivity(intent);
        }
        if(selectedFromList is MenuContentItem)
        {
            var intent = new Intent(this, typeof(YOUR_ACTIVITY2));
            StartActivity(intent);
        }
    };
