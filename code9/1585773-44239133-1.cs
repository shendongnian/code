    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Class1 change = new Class1();
            change.ChangeLabelText(this);
        }
        public void ChangeLabel(string msg, Label label)
        {
            if (label.InvokeRequired)
                label.Invoke(new MethodInvoker(delegate { label.Text = msg; }));
            else
                label.Text = msg;
        }
    }
    class Class1
    {
        public void ChangeLabelText(System.Windows.Forms.Form form)
        {
            if(form != null)
            {
                var labelIdWhoseTextNeedsToChange = "label2"; // Or any dynamic logic to determine which label will have to be updated.
                var labelControl = form.Controls.Find(labelIdWhoseTextNeedsToChange, false);
                if(labelControl != null)
                {
                    form.ChangeLabel("Surname", labelControl);
                }
            }
        }
    }
