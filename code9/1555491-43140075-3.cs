    public partial class MyButton : Button
    {
        public MyButton()
        {
            InitializeComponent();
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            var form = this.FindForm();
            if (form != null)
                if (this == form.AcceptButton)
                    this.BackColor = Color.RosyBrown;
        }
    }
