    using ProjectLibrary;
    using ProjectOnPc; //if You won't include this, You cannot use ext. method
    public void Main(string[] args)
    {
        ClassA mObj = new ClassA();
        mObj.SaveToFile("c:\\MyFile.xml");
    }
