    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sf.Alignment = StringAlignment.Center; // vertical center
            sf.LineAlignment = StringAlignment.Center; // horizontal center
        }
        private int boxSize = 30;
        private bool EnemyKilled = false;
        private Point pntHero = new Point(0, 0);
        private Point pntEnemy = new Point(3, 3);
        private Font fnt = new Font("Lucida", 10);
        private StringFormat sf = new StringFormat();
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) pntHero.Offset(1,0);
            else if (e.KeyCode == Keys.Left) pntHero.Offset(-1, 0);
            else if (e.KeyCode == Keys.Up) pntHero.Offset(0, -1);
            else if (e.KeyCode == Keys.Down) pntHero.Offset(0, 1);
            if (pntHero.Equals(pntEnemy))
            {
                EnemyKilled = true;
            }
            this.Invalidate();
            Console.WriteLine("HERO: " + pntHero.ToString());
            Console.WriteLine("ENEMY: " + pntEnemy.ToString());
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rc;
           
            rc = new Rectangle(new Point(pntEnemy.X * boxSize, pntEnemy.Y * boxSize), new Size(boxSize, boxSize));
            e.Graphics.DrawRectangle(Pens.White, rc);
            e.Graphics.DrawString(EnemyKilled ? "X" : "O", fnt, Brushes.Orange, (RectangleF)rc, sf);
            rc = new Rectangle(new Point(pntHero.X * boxSize, pntHero.Y * boxSize), new Size(boxSize, boxSize));
            e.Graphics.DrawRectangle(Pens.White, rc);
            e.Graphics.DrawString("@", fnt, Brushes.Green, (RectangleF)rc, sf);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            fnt.Dispose();
        }
    }
