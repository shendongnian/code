    public class Activity1 : Activity, View.IOnTouchListener
    {
       public bool OnTouch(View v, MotionEvent e)
       {
           switch (e.Action)
           {
               case MotionEventActions.Down:
                    //Do whatever you want in Down Key
                   break;
               case MotionEventActions.Up:
                  //Do whatever you want in Up Key
                   break;
           }
           return true;
       }
    }
