    public class Form1 : Form
    {
        public static Form1 LastInstance
        {
            get;
            private set;
        }
        public Form1()
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
            Form2 f2Instance = Form2.LastInstance;
            if (f2Instance == null)
                f2Instance = new Form2();
            f2Instance.Show();
        }
