    class MyOnPreDrawListener : Java.Lang.Object, ViewTreeObserver.IOnPreDrawListener
    {
        private MainActivity mainActivity;
        public MyOnPreDrawListener(MainActivity mainActivity)
        {
            this.mainActivity = mainActivity;
        }
        public bool OnPreDraw()
        {
           //Do your logic 
        }
    }
    fabContainer.ViewTreeObserver.AddOnPreDrawListener(new MyOnPreDrawListener(this)); 
     
