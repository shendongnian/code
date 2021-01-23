    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Class1 btn_class = new Class1(this);
            btn_class.Result();
        }
    }
    class Class1
    {
        private Form1 _form;
        public Class1(Form1 form)
        {
            this._form = form;
        }
        public void Result()
        {
            _form.listBox1.Items.Add("hello");
        }
    }
