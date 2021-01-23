    public interface IBeginner
    {
       int AchBeginner{get;set;}
    }
    
    public void Form1 : Form, IBeginner
    {
       public int AchBeginner{get;set;}
    
       //The place you create Form2
       Form2.Beginner = this;
    }
    
    public void Form2 : Form
    {
       public IBeginner Beginner{get;set;}
    
       //Here you can access
       int achBeginner = Beginner.AchBeginner:
    }
