    public class MyRecyclerViewAdapter : RecyclerView.Adapter,IItemHelper
    {
        List<string> items;
        ...
        public MyRecyclerViewAdapter(List<string> data)
        {
            items = data;
        }
        ...
        //Called when an item has been dismissed by a swipe.
        public void onItemDismiss(int position)
        {
            items.RemoveAt(position);
            NotifyItemRemoved(position);
        }
    }
