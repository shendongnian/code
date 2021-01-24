    public partial class LabledPictureBox : PictureBox
    {
        public LabledPictureBox()
        {
            InitializeComponent();
        }
        #region properties
        // I needed to override these properties to make them Browsable....
        [Browsable(true)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }
        [Browsable(true)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }
        [Browsable(true)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }
        #endregion properties
        
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            // This is actually the only code line that's needed to add the text to the picture box
            TextRenderer.DrawText(pe.Graphics, this.Text, this.Font, pe.ClipRectangle, this.ForeColor);
        }
    }
