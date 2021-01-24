    namespace WindowsFormsApplication5
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                CustomGroupBox gb = new CustomGroupBox();
                gb.Location = new Point(5, 5);
                gb.Size = new Size(200, 100);
                this.Controls.Add(gb);
            }
        }
    
    
        public class CustomGroupBox : GroupBox
        {
            private Color borderColor;
    
            public Color BorderColor
            {
                get { return this.borderColor; }
                set { this.borderColor = value; }
            }
    
            public CustomGroupBox()
            {
                this.borderColor = Color.Red;
            }
    
            protected override void OnPaint(PaintEventArgs e)
            {
                Size tSize = TextRenderer.MeasureText(this.Text, this.Font);
    
                Rectangle borderRect = e.ClipRectangle;
                borderRect.Y += tSize.Height / 2;
                borderRect.Height -= tSize.Height / 2;
                ControlPaint.DrawBorder(e.Graphics, borderRect, this.borderColor, ButtonBorderStyle.Solid);
    
                Rectangle textRect = e.ClipRectangle;
                textRect.X += 6;
                textRect.Width = tSize.Width;
                textRect.Height = tSize.Height;
                e.Graphics.FillRectangle(new SolidBrush(this.BackColor), textRect);
                e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), textRect);
            }
        }
    }
