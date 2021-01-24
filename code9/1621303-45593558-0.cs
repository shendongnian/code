    public class MyUserControl
    {
        internal delegate void MyDelegate();
        (...)
    }
    
    public class MyViewModel
    {
        public MyVieWModel(SessionModel session)
        {
            this.session = session;
            MyUserControl.MyDelegate = AddItem;
        }
    
        public void AddItem()
        {
            (...)
        }
    }
