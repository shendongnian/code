    [ComVisible(true)]
    public class Ribbon1 : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        private Timer timer = new Timer();
        
        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
            timer.Interval = 1000;
            timer.Start();
            timer.Tick += (sender, args) => ribbon.InvalidateControl("MyButton");
        }
        public Bitmap Ribbon_GetHelloImage(Office.IRibbonControl ctrl)
        {
            var bitmap = new Bitmap(32, 32);
            var flagGraphics = Graphics.FromImage(bitmap);
            flagGraphics.DrawString(DateTime.Now.Second.ToString(), 
                new Font(FontFamily.GenericSansSerif, 10), 
                Brushes.Red, 12, 0);
            return bitmap;
        }
        public void Ribbon_SayHello(Office.IRibbonControl ctrl)
        {
            MessageBox.Show("Hello", "Hello");
        }
