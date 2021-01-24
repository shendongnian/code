    public delegate int MyDelegate1(double param);
    public delegate int MyDelegate2(double param);
    public int MyFunction(double p) { return 1; }
   	MyDelegate1 del1 = MyFunction;
   	MyDelegate2 del2 = (MyDelegate2)del1;
