    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void DrawCircle(int x, int y, int transparency, Graphics graphics)
        {
            if (transparency < 0)
                transparency = 0;
            else if (transparency > 255)
                transparency = 255;
    
            SolidBrush brush = new SolidBrush(Color.FromArgb(transparency, 255, 0, 0));
    
            graphics.FillEllipse(brush, new Rectangle(x, y, 25, 25));
            brush.Dispose();
            graphics.Dispose();
        }
    
        private void TransparentPanel1_Paint(object sender, PaintEventArgs e)
        {
            DrawCircle(10, 10, 255, e.Graphics);
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            transparentPanel1.Enabled = false;
            transparentPanel1.Paint += TransparentPanel1_Paint;
            transparentPanel1.BringToFront();
        }
    }
    
    public class TransparentPanel : Panel
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return cp;
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }
    }
