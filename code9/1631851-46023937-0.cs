    public partial class Form2 : Form
    {
        private Form1 _form;
        public Form2(Form1 form)
        {
            InitializeComponent();
            _form = form;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            for (int m = 0; m < _form.strarray.Length; m++)
            {
               label.Text="Hello";
            }
        }
    }
