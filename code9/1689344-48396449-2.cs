    public override View GetView(int position, View convertView, ViewGroup parent)
    {
            var view = convertView;
    
            if (view == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.list_view_dataTemplate, parent, false);
    
                var txtName = view.FindViewById<TextView>(Resource.Id.textView1);
                var txtAge = view.FindViewById<TextView>(Resource.Id.textView2);
                var txtEmail = view.FindViewById<TextView>(Resource.Id.textView3);
                var button1 = view.FindViewById<Button>(Resource.Id.button1);
                view.Tag = new ViewHolder() { txtName = txtName, txtAge = txtAge, txtEmail = txtEmail, button1 = button1 };
                button1.Tag = position;
                button1.Click += (sender, args) => {
                   Toast.MakeText(Application.Context, "pos: " + ((Button)sender).Tag.ToString(), ToastLength.Short).Show();
                };
            }
    
            var holder = (ViewHolder)view.Tag;
    
            holder.txtName.Text = "name " + position;
            holder.txtAge.Text = "age " + position;
            holder.txtEmail.Text = "email " + position;
            holder.button1.Tag = position;
            return view;    
        }
