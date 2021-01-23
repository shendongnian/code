    public class MyClass
    {
        string [] singleExtensions;
    
        public void extractExtensions(string s)
        {
            singleExtensions = s.Split(',');
        
        }    
    }
    public partial class Form1 : Form
    { 
        // instance of class:
        MyClass _myClass = new MyClass();
    }
