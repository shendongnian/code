    static myViewModel
    {
         myCommand = new DelegateCommand<bool?>(myMethod);
    }
    private static void myMethod (bool? myBoolean)
    {
         if (myBoolean.HasValue)
         {
             MessageBox.Show("myBoolean was not null");
         }
         if (myBoolean.GetValueOrDefault(true))
         {
             MessageBox.Show("myBoolean was either true or null");
         }
    }
