	namespace Pong
	{
		public partial class Form1 : Form
		{
			public Timer gameTime;
			const int screenWidth = 1248;
			const int screenHeight = 720;
			public Form1()
			{
				InitializeComponent();
				this.Height= screenHeight;
				this.Width=screenWidth;
				this.StartPosition=FormStartPosition.CenterScreen;
				
				Player player = new Player(this);
				player.PlayerSize = new Size(20, 50);
				player.Location = new Point(player.PaddleBox.Width / 2, ClientSize.Height/2-player.PaddleBox.Height/2); // <-- the location is always the upperleft point. don't do this...
				player.BackColor = Color.Blue;
				
				gameTime = new Timer();
				gameTime.Enabled = true;
			}
			private void gameTime_Tick(object sender, EventArgs e)
			{
			}
			private void Form1_Load(object sender, EventArgs e)
			{
			}
		}
		
		public class Player
		{
			private PictureBox _paddleBox;
			
			protected Size PlayerSize
			{
				get
				{
					return _paddleBox.Size;
				}
				set
				{
					if (PlayerSize.Height == 0 || PlayerSize.Width == 0)
						throw new ArgumentException("Size must be greater than 0");
					_paddleBox.Size = value;
				}
			}
			
			protected Point Location
			{
				get { return PaddleBox.Location; }
				set	{ PaddleBox.Location = value; }
			}
			protected Color BackColor
			{
				get { return PaddleBox.BackColor; }
				set { PaddleBox.BackColor = value; }
			}
			
			public Player(Form form)
			{
				PaddleBox = new PictureBox();
				form.Controls.Add(PaddleBox);
			}
		}	
	}
