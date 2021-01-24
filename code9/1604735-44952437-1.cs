    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Font fnt = new Font("Lucida", 10);
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int x = pctrBxHero.Location.X;
            int y = pctrBxHero.Location.Y;
            if (e.KeyCode == Keys.Right) x += 30;
            else if (e.KeyCode == Keys.Left) x -= 30;
            else if (e.KeyCode == Keys.Up) y -= 30;
            else if (e.KeyCode == Keys.Down) y += 30;
            pctrBxHero.Location = new Point(x, y);
            Console.WriteLine("HERO --- X = : {0} ---- Y = : {1}", x, y);
            Console.WriteLine("ENEMY --- X = : {0} ---- Y = : {1}", pctrBxEnemy.Location.X, pctrBxEnemy.Location.Y);
        }
        private void pctrBxHero_Paint(object sender, PaintEventArgs e)
        { 
            e.Graphics.DrawString("@", fnt, Brushes.Green, new Point(0, 0));
        }
        private void pctrBxEnemy_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("X", fnt, Brushes.Orange, new Point(0, 0));
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            fnt.Dispose();
        }
    }
