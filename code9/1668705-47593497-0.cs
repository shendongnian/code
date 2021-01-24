    public partial class Form1 : Form
    {        
       static EventWaitHandle FocusProgram = new EventWaitHandle(false, EventResetMode.ManualReset, "FocusMyProgram198472");
        //private delegate void focusConfirmed(); Thread FocusCheck;
        private void focus()
        {
            FocusProgram.WaitOne();
            this.Invoke(new Action(() => {
                this.Show();
                this.BringToFront();
            }));
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    e.Cancel = true;
                    FocusProgram.Reset();
                    ThreadPool.QueueUserWorkItem(new WaitCallback((o) => focus()));
                    Hide();
                    break;
            }
        }
        
        public static void ShowHidden()
        {
            FocusProgram.Set();
        }
}
    
 
    static class Program
        {
            private static Mutex me;
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                if (Exists())
                {
                    Form1.ShowHidden();                              
                    return;
               }            
                Application.Run(new Form1());
            }
    
            private static bool Exists()
            {
                var createdNew = false;
                me = new Mutex(true, "TestForm123545654", out createdNew);
                return !createdNew;
            }
        }
