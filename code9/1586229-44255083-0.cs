    public static void WrapperMethod(object sender, EventArgs e)
    {
        MyDLLName.MyClass.MyMethod(sender.Tostring());
    }
    myButton.OnClick += WrapperMethod;
