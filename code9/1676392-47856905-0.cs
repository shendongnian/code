    public class MyUserControl : UserControl 
    {
       public MyUserControl() : base() 
       {
       }
       // add common behaviour here (validation, etc)
    }
    public class MyTextBox : MyUserControl 
    {
       public MyTextBox() : base() 
       {
          Add(new TextBox());
       }
       ...
    }
