    public void MyMethod()
    {
        var n = MyMethodToIgnore(sample);
        MyTestedMethod(n);
    }
    
    public void MyTestedMethod(dynamic n) {
      // do the calculation
    }
