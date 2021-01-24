    public override View GetView(int position, View convertView, ViewGroup parent)
    {
        View row = convertView;
        if (row == null)
        {
            row = LayoutInflater.From(Context).Inflate(Resource.Layout.ListBox, null, false);
        }
        CheckBox txtName = row.FindViewById<CheckBox>(Resource.Id.cbName);
        txtName.Text = _list[position].Name;
        txtName.Checked = _list[position].IsSelected;
        txtName.CheckedChange -= TxtName_CheckedChange;
        txtName.CheckedChange += TxtName_CheckedChange;
        return row;
    }
