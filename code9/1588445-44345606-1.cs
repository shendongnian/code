    public void OnItemClick(object sender, PdfAdapterClickEventArgs e)
    {
       var view = args.View; //this is your view
       Toast.MakeText(this, $"Item Position: {args?.Position}", ToastLength.Short).Show();
    }
