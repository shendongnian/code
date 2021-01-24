    public class MyListener : Java.Lang.Object, RecyclerView.IOnItemTouchListener
    {
        public MyListener()
        {
            //pass data if you want
        }
        public bool OnInterceptTouchEvent(RecyclerView recyclerView, MotionEvent @event)
        {
            //code here
        }
        public void OnRequestDisallowInterceptTouchEvent(bool disallow)
        {
            //code here
        }
        public void OnTouchEvent(RecyclerView recyclerView, MotionEvent @event)
        {
            //code here
        }
    }
