    // textbox no flicker
    public partial class TexttBoxNF : TextBox
    {
        public TexttBoxNF()
        {
        }
        public TexttBoxNF(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            //Activate double buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            //Enable the OnNotifyMessage event so we get a chance to filter out 
            // Windows messages before they get to the form's WndProc
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
        }
        //http://stackoverflow.com/questions/442817/c-sharp-flickering-listview-on-update
        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
    }
