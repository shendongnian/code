    public class MyTextBox: RichTextBox
    {
        private HScrollBar m_bar;
        [EditorBrowsable]
        [Category("own")]
        public HScrollBar Bar
        {
            get
            {
                return m_bar;
            }
            set
            {
                if (m_bar != value)
                {
                    m_bar = value;
                    OnFontChanged(EventArgs.Empty);
                }
            }
        }
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            if (m_bar == null) return;
            BackColor = System.Drawing.Color.Red;
        }
    }
