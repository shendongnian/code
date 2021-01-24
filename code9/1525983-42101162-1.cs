    private void spinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
    {
            Spinner spinner = (Spinner)sender;
    
            string toast = string.Format ("The planet is {0}", spinner.GetItemAtPosition (e.Position));
            Toast.MakeText (this, toast, ToastLength.Long).Show ();
    }
