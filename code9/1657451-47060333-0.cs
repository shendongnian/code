    public partial class ToggleNumericControl : UserControl
    {
        public ToggleNumericControl()
        {
            InitializeComponent();
        }
        public override string Text
        {
            get { return checkBox.Text;  }
            set { checkBox.Text = value; }
        }
        public bool Checked
        {
            get { return checkBox.Checked;  }
            set { checkBox.Checked = value; }
        }
        public decimal Value
        {
            get { return numericUpDown.Value; }
            set { numericUpDown.Value = Value; }
        }
    }
