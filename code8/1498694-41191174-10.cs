    public class Form2 : Form
    {
       public Form2(Form form1)
       {
           //Register Event LevelUp from Form1
           form1.LevelUp += (args) => 
           {
              if (args.Level == 5)
              //Level 5 reached
           }
       }
    }
