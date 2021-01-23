    public class Form2 : Form
    {
        public static Form2 LastInstance
        {
            get;
            private set;
        }
        public Form2()
        {
            // do the stuff your constructor does
            ...
 
            // Remember this instance as the last created instance
            LastInstance = this;
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            LastInstance = null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1Instance = Form1.LastInstance;
            if (f1Instance == null)
                f1Instance = new Form1();
            f1Instance.Show();
        }
