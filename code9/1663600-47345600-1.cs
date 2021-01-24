    public override View GetView(int position, View convertView, ViewGroup parent)
    {
        var item = mList[position];
        if (convertView == null)
        {
            convertView = mContext.LayoutInflater.Inflate(Resource.Layout.CustomRowView,null);
        }
        var btn = convertView.FindViewById<Button>(Resource.Id.mBtn);
        btn.Click += Btn_Click;
        return convertView;
    }
    private void Btn_Click(object sender, EventArgs e)
    {
        //do your job here
    }
