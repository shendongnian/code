        override View GetView(int position, View convertView, ViewGroup parent)
        {
            DataViewHolder holder = null;
            var view = convertView;
            if(view != null)
            {
                holder = view.Tag as DataViewHolder;
            }
            if (holder == null)
            {
                view = LayoutInflater.From(mContext).Inflate(Resource.Layout.FactAdapter, null, false);
                holder = new DataViewHolder();
    
                holder.txtid = view.FindViewById<TextView>(Resource.Id.idtxt);
                holder.txtName = view.FindViewById<TextView>(Resource.Id.Nametxt);
                holder.txtPhone = view.FindViewById<TextView>(Resource.Id.Phonetxt);
                holder.txtActive = view.FindViewById<TextView>(Resource.Id.Activetxt);
    
                view.Tag = holder;
            }
    
            holder.txtid.Text = Convert.ToString(mitems[position].id);
            holder.txtName.Text = mitems[position].Name;
            holder.txtPhone.Text = mitems[position].Phone;
    
            holder.txtActive.Text = Convert.ToString(mitems[position].Active);
    
            if (holder.txtActive.Text == "1")
            {
                holder.txtName.SetBackgroundColor(Color.LightGreen);
                holder.txtPhone.SetBackgroundColor(Color.LightGreen);
            }
            else if (holder.txtActive.Text == "2")
            {
                holder.txtName.SetBackgroundColor(Color.Orange);
                holder.txtPhone.SetBackgroundColor(Color.Orange);
            }
            else
            {
               holder.txtName.SetBackgroundColor(Color.White);
               holder.txtPhone.SetBackgroundColor(Color.White);
            }
            return view;
        }
