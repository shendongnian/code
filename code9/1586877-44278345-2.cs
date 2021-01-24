    public class Form1 : Form 
    {
       private Form _frm2;
    
    
       //That code you probably have somewhere. You need to make sure that this Form instance is accessible inside the handler to use it.
       public void Stuff() {
         _frm2 = new Form2();
         _frm2.Show();
       }
    
        private void Form1_Click(object sender, EventArgs e)
        {
            _frm2.Focus(); //or _frm2.Activate();
        }
    
       
    }
