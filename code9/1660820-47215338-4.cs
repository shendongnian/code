    public partial class UserControl1 : TableLayoutPanel
    {
        public RichTextBox res;
        public CheckBox checkBox;
        public RichTextBox steps;
        public UserControl1()
        {
            InitializeComponent();
            res = new RichTextBox();
            checkBox = new CheckBox();
            steps = new RichTextBox();
            this.ColumnCount = 3;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Controls.Add(this.checkBox, 0, 0);
            this.Controls.Add(this.steps, 1, 0);
            this.Controls.Add(this.res, 2, 0);
        }
    }
    
