    //some code ...
    MyClass checker = new MyClass("C:\a.txt");
    checker.StatusChecked += new StatusCheck(myVoid);
    checker.Start();
    //some more code ..
    private void myVoid(bool result)
    {
        Console.WriteLine("My result is: " + result );
    }
