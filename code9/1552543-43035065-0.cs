    public class Form2 : Form
    {
       //This property will hold the text, so populate the textbox from it   
       string TextProperty {get;set;}
    
       public form2(string textFromForm1)
       {
          TextProperty = textFromForm1;
       }
    }
