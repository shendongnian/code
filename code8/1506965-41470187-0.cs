    public partial class Form1 : Form
    {
        private Button btnGetInteger;
        private Button btnGetMenuStrip;
        private Button btnGetString;
        private Form2 _form2;
        private Form2.ReturnType _getType;
        private Object _form2Argument;
        public Form1()
        {
            InitializeComponent();
            btnGetInteger = new Button();
            btnGetInteger.Click += Form2_GetInteger;
            btnGetMenuStrip = new Button();
            btnGetMenuStrip.Click += Form2_GetInteger;
            btnGetString = new Button();
            btnGetString.Click += Form2_GetString;
            Shown += (s, e) => { Form2_CreateMenuStrip(s, EventArgs.Empty); };
        }
        public void Form2_ThreadChanged(object sender, ProgressChangedEventArgs e)
        {
            var returned = (Form2.ReturnType)e.ProgressPercentage;
            switch (returned)
            {
                case Form2.ReturnType.MenuStrip:
                    var menuStrip = (MenuStrip)e.UserState;
                    this.Controls.Add(menuStrip);
                    break;
                case Form2.ReturnType.Integer:
                    var numberBack = (int)e.UserState;
                    Text = String.Format("Form1 : (int){0}", numberBack);
                    break;
                case Form2.ReturnType.String:
                    var stringBack = e.UserState.ToString();
                    Text = String.Format("Form1 : (String){0}", stringBack);
                    break;
            }
        }
        public void Form2_ThreadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _form2Argument = null;
            if (e.Error != null)
            {
                String title;
                if (_form2 != null)
                {
                    title = String.Format("{0}: {1}", _form2.Text, e.Error.GetType());
                } else
                {
                    title = String.Format("Form2: {0}", e.Error.GetType());
                }
                MessageBox.Show(e.Error.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (_form2 != null)
            {
                _form2.Close();
                _form2.Dispose();
                _form2 = null;
            }
            btnGetInteger.Enabled = true;
            btnGetMenuStrip.Enabled = true;
            btnGetString.Enabled = true;
        }
        private void Form2_CreateMenuStrip(object sender, EventArgs e)
        {
            if (_form2 == null)
            {
                _getType = Form2.ReturnType.MenuStrip;
                var item = new ToolStripMenuItem(Text);
                item.Click += Form2_GetInteger;
                _form2Argument = item;
                Form2_StartWork();
            }
        }
        private void Form2_GetInteger(object sender, EventArgs e)
        {
            if (_form2 == null)
            {
                _getType = Form2.ReturnType.Integer;
                Form2_StartWork();
            }
        }
        private void Form2_GetString(object sender, EventArgs e)
        {
            if (_form2 == null)
            {
                _getType = Form2.ReturnType.String;
                Form2_StartWork();
            }
        }
        private void Form2_StartWork()
        {
            btnGetInteger.Enabled = false;
            btnGetMenuStrip.Enabled = false;
            btnGetString.Enabled = false;
            _form2 = new Form2();
            _form2.Show(); // Show returns immediately
            _form2.StartThread(this, _form2Argument, _getType);
        }
    }
