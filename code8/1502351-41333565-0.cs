        delegate string GetMyAddress(string baseAddress);
        class Grandparent
        {
            protected readonly GetMyAddress _baseGetMyAddress;
            protected GetMyAddress _getMyAddress;
            public string BaseAddress = "Foo Street";
            public Grandparent()
            {
                _baseGetMyAddress = (a) => { return String.Format("Grandparent: {0}", a); };
                _getMyAddress = _baseGetMyAddress;
            }
            // no longer virtual
            public string MyAddress()
            {
                return _getMyAddress(BaseAddress);
            }
        }
        class Parent : Grandparent
        {
            public Parent()
            {
                // does something differing from the base
                _getMyAddress = (a) => { return String.Format("Parent: {0}", a); };
            }
        }
        class Child : Parent
        {
            public Child()
            {
                // does what its parent tells it to do
            }
        }
        class ChildTakingAfterGrandparent : Parent
        {
            public ChildTakingAfterGrandparent()
            {
                // does what its grandparent does
                _getMyAddress = _baseGetMyAddress;
            }
        }
        class WillfulChild : Parent
        {
            public WillfulChild()
            {
                // does its own thing
                _getMyAddress = (w) => { return String.Format("WillfulChild: {0}", w); };
            }
        }
        public static void Run()
        {
            var gp = new Grandparent();
            var p = new Parent();
            var c = new Child();
            var cg = new ChildTakingAfterGrandparent();
            var wc = new WillfulChild();
            Console.WriteLine("gp.MyAddress(): \"{0}\"", gp.MyAddress());
            Console.WriteLine("p.MyAddress():  \"{0}\"", p.MyAddress());
            Console.WriteLine("c.MyAddress():  \"{0}\"", c.MyAddress());
            Console.WriteLine("cg.MyAddress(): \"{0}\"", cg.MyAddress());
        }
