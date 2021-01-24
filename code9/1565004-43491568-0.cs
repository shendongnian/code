    public partial class Form1 : Form
    {
        internal void get_data(int mydata)//Change to internal or public, as default is private
        {
            //code
        }
        private void button1_Click(object sender, EventArgs e)
        {
            prog var1 = new prog();
            var1.start_data(this);//pass along instance of your main form
        }
    }
    public class prog
    {
        private Form1 MainForm;
        public void start_data(Form1 form)
        {
            MainForm = form;//set form
            Thread ct = new Thread(doSmt);
            ct.Start();
        }
        private void doSmt()
        {
            int data = 40;
            MainForm.get_data(data);  //use form
        }
    }
