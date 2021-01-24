    public partial class Form1 : Form
    {
        public static int UniversalWidth;
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UniversalWidth = Width;
        }
    //...
