    public partial class UICirclePicture : PictureBox
    {
        [Browsable(false)]
        public int Depth { get; set; }
        [Browsable(false)]
        public SprikiwikiUI Ui
        {
            get { return SprikiwikiUI.Instance; }
        }
        [Browsable(false)]
        public MouseState MouseState { get; set; }
        public UICirclePicture()
        {
            BackColor = Ui.GetApplicationBackgroundColor();
            SizeMode = PictureBoxSizeMode.StretchImage;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(new Rectangle(0, 0, this.Width - 1, this.Height - 1));
                this.Region = new Region(gp);
            }
        }
    }
