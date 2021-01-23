    public class scroll : RecyclerView.OnScrollListener
    {
        public delegate void DoSomething();
        public DoSomething mDoText;
        public scroll()
        {
        }
        public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
        {
            base.OnScrolled(recyclerView, dx, dy);
            var visibleItemCount = recyclerView.ChildCount;
            var totalItemCount = recyclerView.GetAdapter().ItemCount;
            // GET LAYOUT MANAGER
            var mLayoutManager = (LinearLayoutManager)recyclerView.GetLayoutManager();
            var latVisible = mLayoutManager.FindLastCompletelyVisibleItemPosition();
            var pasVisibleItem = mLayoutManager.FindFirstVisibleItemPosition();
            if ((visibleItemCount + pasVisibleItem) >= (totalItemCount))
            {
                mDoText.Invoke();
            }
            else
            {
                Console.WriteLine("visibleItemCount + pasVisibleItem =  " + (visibleItemCount + pasVisibleItem));
            }
        }
    }
