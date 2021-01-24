    if (! holder.DeleteButton.HasOnClickListeners)
    {
     holder.DeleteButton.Click += (sender, args) =>
            {
                IngredientList.RemoveAt(position);
                NotifyDataSetChanged();
            };
    
    }
				
