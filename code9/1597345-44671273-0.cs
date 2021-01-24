    namespace MyApplication
    {
        public delegate void MyEventHandler(object source, EventArgs e);
    
        public class MyForm : Form
        {
            public event MyEventHandler OnInitialData;
    
            private void btnOk_Click(object sender, EventArgs e)
            {
                 OnInitialData?.Invoke(this, null);
            }
        }
    }
