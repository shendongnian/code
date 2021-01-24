    public class MyForm : System.Windows.Forms.Form
     {       
     public MyForm()
     {
     this.Text = "Hello Form";
     this.Click+=Form_Click;
     }
     public static void Main()
     {
     	System.Windows.Forms.Application.Run(new MyForm());
    
     }
    
     private void Form_Click(object sender, System.EventArgs e){
     	MyForm2 form2=new MyForm2();
     	form2.ShowDialog();
     }
     }
