    public class MyUserControl : UserControl
    {
       public string Name
       {
          //Inside your UserControl you can access your Controls directly
          get{return textBoxName.Text;}
          set {textBoxName.Text = value;}
       }
    }
    
    public class MyForm : Form
    {
       //This set the Text in your UserControl Textbox.
       myUserControl.Name = "Mr. Example";
    }
