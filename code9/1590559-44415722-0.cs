    public partial class Form1 : Form
    {
        bool goleft = false;
        bool goright = false;
        int JumpSpeed = 0; //current vertical speed
        int force = 8; //initial jump speed
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }
            if (e.KeyCode == Keys.Space && JumpSpeed==0) //!jumping to prevent "double jump"
            {
                JumpSpeed = force; //start jumping with full power
            }
        }
        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (goleft)
            {
                player.Left -= 5;
            }
            if (goright)
            {
                player.Left += 5;
            }
            if (player.Bounds.IntersectsWith(Door.Bounds))
            {
                timer1.Stop();
                MessageBox.Show("You Won!");
                this.Close();
            }
            JumpSpeed -= 1; //reduce the vertical speed = gravity -> choose higher value to bring him back on the ground quicker
            player.Top -= JumpSpeed;
            foreach (PictureBox x in this.Controls) //This should work as well if not change back
            {
                if (x.Tag == "p")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds)) //if the player should be able to jump/walk on something the code is
                    {
                        player.Top = x.Top - player.Height;
                        JumpSpeed = 0; //the player stops falling
                    }
                }
            }
        }
    }
