    // event args.
    public class RequestChildEventArgs : EventArgs
    {
        public Child2 Child { get;set; }
    }
    public class UC1
    {
        // do something when you need the child2
        public void DoSomething()
        {
            var child2 = GetChild2();
            if(child2 == null)
                // cry.
        }
        // this method requests a reference of child2
        private Child2 GetChild2()
        {
            // check if the event is assigned.
            if(RequestChild == null)
                return null;
            RequestChildEventArgs args = new RequestChildEventArgs();
            RequestChild2(this, args);
            return args.Child;
        }
        public event EventHandler<RequestChildEventArgs> RequestChild2;
    }
    // user control 2
    public class UC2
    {
        public Child2 Child2 { get; } = new Child2();
    }
    // the mainwindow that tunnels the Child2
    public class MainWindow
    {
        private UC1 _uc1;
        private UC2 _uc2;
        public MainWindow()
        {
            _uc1 = new UC1();
            _uc2 = new UC2();
            _uc1.RequestChild2 += (s, e) => e.Child = _uc2.Child2;
        }
    }
