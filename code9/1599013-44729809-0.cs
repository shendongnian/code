    class Example
    {
        static private readonly MyClass[] _myClasses;
        static public Example()
        {
            _myClasses= new MyClass[] { null,
                                        new MyClass(0,0),
                                        new MyClass(0,1),
                                        new MyClass(1,1),
                                        new MyClass(2,4) };
        }
        public MyClass[] Prop
        {
            get
                {
                    return _myClasses;
                }
        }
    }
