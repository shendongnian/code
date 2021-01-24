     public partial class Form1 : Form
    {
        delegate void funDel();
        private waiting waitForm;
        private event funDel funEvent;
        public Form1()
        {
            InitializeComponent();
            funEvent += Form1_funEvent;
        }
        private void Form1_funEvent()
        {
         
           waitForm.Close();
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                if (InvokeRequired) // Line #1
                {
                    this.Invoke(new MethodInvoker(() => button1.Text = "Proccessing"));
                  
                }
                else
                {
                    button1.Text = "Proccessing";
                }
                
            });
            waitForm = new waiting();
            timer1.Start();
            waitForm.ShowDialog();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            funEvent();
        }
    }
