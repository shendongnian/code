    MyClass c = new MyClass();
    MyMethod(c);
    MyRefMethod(ref c);
    public void MyMethod(MyClass innerc)
    {
        innerc = new MyClass(); //stays local, c is still its old reference
    }
    public void MyRefMethod(ref MyClass innerc)
    {
        innerc = new MyClass(); //c becomes a new reference to the local innerc
    }
