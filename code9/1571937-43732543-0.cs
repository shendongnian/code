    public interface ICoolStuff
    {
       public String HelloWorld();
    }
    
    public class TextBox : Control, ICoolStuff
    {
        // *snip*
    }
    
    public class TextBoxPanel : Panel, ICoolStuff
    {
        public string HelloWorld()
        {
            return this.textbox.HelloWorld();
        }
    }
