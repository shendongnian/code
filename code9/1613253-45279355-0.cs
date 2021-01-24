    public class SecondClass
    {
        public string TextBox1Text {  get; set; }
    }
    
    public class MainClass
    {
        SecondClass sc = new SecondClass();
     
    
        public string TextBox1Text
        {   
            get { return textBox1.Text; } 
            set { textBox1.Text = value; } 
        }
    
    
        public MainClass
        {   
            sc.TextBox1Text = this.TextBox1Text;
        }
    }
