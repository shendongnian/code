    using System.Windows.Forms;
    using Snake.Game.Classes;
    
    namespace Snake.Game.Forms
    {
        public partial class SnakeGameForm : Form
        {
            private readonly SnakeGame _game;
    
            public SnakeGameForm(SnakeGame game)
            {
                InitializeComponent();
                _game = game;
            }
    
            private void button1_Click(object sender, System.EventArgs e)
            {
                MessageBox.Show($"Direction of snake is '{ _game.Direction}'.");
            }
        }
    }
