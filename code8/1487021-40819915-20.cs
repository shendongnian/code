        private class MyViewHolder : Java.Lang.Object
        {
            public TextView lblTitle { get; set; }
            public ImageView imgThumbnail { get; set; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var inflater = LayoutInflater.From(parent.Context);
            MyViewHolder holder = null;
            var view = convertView;
            if (view != null)
                holder = view.Tag as MyViewHolder;
            if (holder == null)
            {
                holder = new MyViewHolder();
                view = inflater.Inflate(Resource.Layout.DishesListItem, parent, false);
                holder.lblTitle = view.FindViewById<TextView>(Resource.Id.Title);
                holder.imgThumbnail = view.FindViewById<ImageView>(Resource.Id.Thumbnail);
                view.Tag = holder;
            }
            holder.lblTitle.Text = data[position].name;
            try
            {
                holder.imgThumbnail.SetImageDrawable(data[position].image);
            }
            catch
            {
                holder.imgThumbnail = null;
            }
            return view;
        }
