    public partial class Form2 : Form
    {
        Graphics g;
        Graphics h;
        Pen p = new Pen(Color.Black, 1);
        Point sp = new Point(0, 0);
        Point ep = new Point(0, 0);
        int k = 0;
        Bitmap bmp =null;
        public Form2()
        {
            InitializeComponent();
            bmp = new Bitmap(panel2.ClientSize.Width, panel2.ClientSize.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(panel2.BackColor);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            p.Color = red.BackColor;
            default1.BackColor = red.BackColor;
         }
        private void color_Click(object sender, EventArgs e)
        {
            Control ctl = sender as Control;
            p.Color = ctl.BackColor;
            default1.BackColor = ctl.BackColor;
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ep = e.Location;
                g.DrawLine(p, sp, ep);
                h = panel2.CreateGraphics();
                h.DrawLine(p, sp, ep);
            }
            sp = ep;
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            sp = e.Location;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                bmp.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
    }
