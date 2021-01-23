    // event args.
    public class RequestChildEventArgs<T> : EventArgs
    {
        public T Child { get; set; }
    }
    public class UC1
    {
        public Child1 Child1 { get; } = new Child1();
        // do something when you need the child2
        public void DoSomething()
        {
            var child2 = GetChild2();
            if (child2 == null)
                // cry.
        }
        // this method requests a reference of child2
        private Child2 GetChild2()
        {
            // check if the event is assigned.
            if(RequestChild2 == null)
                return null;
            RequestChildEventArgs<Child2> args = new RequestChildEventArgs<Child2>();
            RequestChild2(this, args);
            return args.Child;
        }
        public event EventHandler<RequestChildEventArgs<Child2>> RequestChild2;
    }
    // user control 2
    public class UC2
    {
        public Child2 Child2 { get; } = new Child2();
        // do something when you need the child1
        public void DoSomething()
        {
            var child1 = GetChild1();
            if(child1 == null)
                // cry.
        }
        // this method requests a reference of child1
        private Child1 GetChild1()
        {
            // check if the event is assigned.
            if(RequestChild1 == null)
                return null;
            RequestChildEventArgs<Child1> args = new RequestChildEventArgs<Child1>();
            RequestChild1(this, args);
            return args.Child;
        }
        public event EventHandler<RequestChildEventArgs<Child1>> RequestChild1;
    }
    // the mainwindow that tunnels the Childs
    public class MainWindow
    {
        private UC1 _uc1;
        private UC2 _uc2;
        public MainWindow()
        {
            _uc1 = new UC1();
            _uc2 = new UC2();
            _uc1.RequestChild2 += (s, e) => e.Child = _uc2.Child2;
            _uc2.RequestChild1 += (s, e) => e.Child = _uc1.Child1;
        }
    }
