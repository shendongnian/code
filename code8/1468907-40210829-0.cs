    public interface IValueHolder
    {
       public int MyValue {get;}
    }
    
    public class FirstForm : Form, IValueHolder
    {
       public int MyValue{get;}
    
       //Do your form stuff
    
       Form2 form = new Form2(this);
    }
