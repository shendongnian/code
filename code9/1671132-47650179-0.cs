    public partial class Life : Form
    {
        private int _money;
        public void AddMoney(int amount)
        {
            _money += amount;
            label1.Text = _money.ToString();
        }
        public Life()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            var startGame = new StartGame(this);
            startGame.Show();
        }
    }
    public partial class StartGame : Form
    {
        private readonly Life _life;
        public StartGame(Life life)
        {
            InitializeComponent();
            _life = life;
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            _life.AddMoney(5);
        }
    }
