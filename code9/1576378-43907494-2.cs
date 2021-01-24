    EditText etname = FindViewById<EditText>(Resource.Id.etname);
    Button saveBtn = FindViewById<Button>(Resource.Id.saveBtn);
    saveBtn.Click += (sender, e) =>
    {
        if (etname.Text != null)
        {
            var preferences = PreferenceManager.GetDefaultSharedPreferences(this);
            var editor = preferences.Edit();
            editor.PutString("Your Name", etname.Text);
            editor.Commit();
        }
    };
