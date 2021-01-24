    public partial class SplBox : Form
    {
         //Global declarations 
         TextBox t2 = new TextBox();
         private Form TempOwnerForm;
         public SplBox(Form TempOwnerForm) {
             this.TempOwnerForm = TempOwnerForm;
         }
         public Form OwnerForm { get { return TempOwnerForm; } set { this.TempOwnerForm = value; } }
    
         public void settxtbox()
         {  
             t2.Text = "Hello World";
             TempOwnerForm.Controls.Add(t2);
         }
    }
