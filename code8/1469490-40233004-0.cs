     public override View GetView(int position, View convertView, ViewGroup parent)
        {
            inflater = (LayoutInflater)activity.ApplicationContext.GetSystemService(Context.LayoutInflaterService);
            itemView = inflater.Inflate(Resource.Layout.item, null);
    
            TextView txtRow = itemView.FindViewById<TextView>(Resource.Id.txtRow);
            CheckBox ckbRow = itemView.FindViewById<CheckBox>(Resource.Id.ckbBox);
    
            ckbRow.SetOnCheckedChangeListener(this);
    
            if (ckbRow.Checked)
              {
                txtRow.Text = "HEHEHE";
                txtRow.SetTextColor(Android.Graphics.Color.White);
              }
              else
              {
                //default color
                txtRow.SetTextColor(Android.Graphics.Color.Black); 
              }
    
            return itemView;
    
        }
