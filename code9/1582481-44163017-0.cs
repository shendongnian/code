    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var pd = new PrintDocument();             
            pd.PrintPage+=(s,ev)=>
            {
                var bmp = new Bitmap(Width, Height);
                this.DrawToBitmap(bmp, new Rectangle(Point.Empty, this.Size));
                ev.Graphics.DrawImageUnscaled(bmp, ev.MarginBounds.Location);
                ev.HasMorePages=false;
            };
            var dlg = new PrintPreviewDialog();
            dlg.Document=pd;            
            dlg.ShowDialog();
        }
    }
