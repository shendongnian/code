    public class Activity1 : Activity, GestureDetector.IOnGestureListener
    {
       public bool OnDown(MotionEvent e)
       {
       }
       public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
       {
       }
       public void OnLongPress(MotionEvent e) {}
       public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
       {
       }
       public void OnShowPress(MotionEvent e) {}
       public bool OnSingleTapUp(MotionEvent e)
       {
           return false;
       }
    }
