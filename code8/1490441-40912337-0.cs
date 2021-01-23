    public class Form
    {
        void Click()
        {
            Form2 f=new Form2(this);
            f.closing += form2Closing;
            f.show()
        }
    
        public void Reload()
        {
            //Load Data
        }
        
        private void form2Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Reload()
        }
    
    }
