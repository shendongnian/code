    public partial class MyButton : Button
    {
        public MyButton()
        {
            InitializeComponent();
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (this == FindForm()?.AcceptButton)
                this.BackColor = Color.RosyBrown;
        }
    }
