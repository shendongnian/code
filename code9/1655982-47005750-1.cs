      public override void
            OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if(SelectedPosition == position)
                holder.ItemView.SetBackgroundResource(Resource.Color.alt_green);
              else
                holder.ItemView.SetBackgroundColor(Color.Transparent);        
        }
