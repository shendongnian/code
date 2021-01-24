    listView.ItemClick += OnListItemClick;
    protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            TableItem t = tableItems[e.Position];
            EditText inputServer = new EditText(this);
            inputServer.Focusable = true;
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("Dialog Title")
                .SetMessage("Dialog Message")
                .SetIcon(Resource.Drawable.Icon)
                .SetView(inputServer)
                .SetNegativeButton("Cancel", (sender2, e2) =>
                {
                    Toast.MakeText(this, "Cancel!", ToastLength.Short).Show();
                })
                .SetPositiveButton("Change the text", (sender2, e2) =>
                {
                    string inputName = inputServer.Text.ToString();
                    t.Heading = inputName;
                    Toast.MakeText(this, "Text changed!", ToastLength.Short).Show();
                });
            builder.Show();
            
            adapter.NotifyDataSetChanged();
        }
