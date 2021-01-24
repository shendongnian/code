    [ComVisible(true)]  // there are cleaner ways to expose COM-visible 
    class MyClass
    {
       public void RunMe()
       {
           var form = new MainForm();
           form.ShowDialog(); // example
       }
    }
