    public class CardViewSwipeListener : ItemTouchHelper.Callback
    { 
         ...
         public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
        {
            if (direction == ItemTouchHelper.End)
            {
                ...
            }
            else if (direction == ItemTouchHelper.Start)
            {
                ...
            }
            recyclerViewAdapter.onItemDismiss(viewHolder.AdapterPosition);
        }
    }
  
    
