    public class Test : Form
    {
       ....
       public void SetLabelText(string name, string value)
       {
           switch(name)
           {
               case "startTime":
                  this.labelForStartTime.Text = value;
                  break;
               case "label1":
                  this.firstLabelToUpdate.Text = value;
                  break;
               ... 
               // and so on for all other labels 
           }
       }
    }
