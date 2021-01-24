    public partial class Form1 : Form
    {
    	private Button centerSquare = new Button();
    
    	public Form1()
    	{
    		InitializeComponent();
    	}
    
    	private void square_Click(object sender, EventArgs e)
    	{
    		Button topLeftSquare = new Button();
    		Button topRightSquare = new Button();
    		Button bottomLeftSquare = new Button();
    		Button bottomRightSquare = new Button();
    
    		Button senderSquare = sender as Button;
    		topLeftSquare.Click += new EventHandler(square_Click);
    		topRightSquare.Click += new EventHandler(square_Click);
    		bottomLeftSquare.Click += new EventHandler(square_Click);
    		bottomRightSquare.Click += new EventHandler(square_Click);
    
    		int newSquareHeight = senderSquare.Height / 2;
    		int newSquareWidth = senderSquare.Width / 2;
    
    		topLeftSquare.Size = new System.Drawing.Size(newSquareHeight, newSquareWidth);
    		topRightSquare.Size = new System.Drawing.Size(newSquareHeight, newSquareWidth);
    		bottomLeftSquare.Size = new System.Drawing.Size(newSquareHeight, newSquareWidth);
    		bottomRightSquare.Size = new System.Drawing.Size(newSquareHeight, newSquareWidth);
    
    		topLeftSquare.Location = new Point(senderSquare.Left, senderSquare.Top);
    		topRightSquare.Location = new Point(senderSquare.Left + newSquareHeight, senderSquare.Top);
    		bottomLeftSquare.Location = new Point(senderSquare.Left, senderSquare.Top + newSquareWidth);
    		bottomRightSquare.Location = new Point(senderSquare.Left + newSquareHeight, senderSquare.Top + newSquareWidth);
    
    		topLeftSquare.BackColor = Color.Red;
    		topRightSquare.BackColor = Color.Red;
    		bottomLeftSquare.BackColor = Color.Red;
    		bottomRightSquare.BackColor = Color.Red;
    
    		this.Controls.Add(topLeftSquare);
    		this.Controls.Add(topRightSquare);
    		this.Controls.Add(bottomLeftSquare);
    		this.Controls.Add(bottomRightSquare);
    
    		this.Controls.Remove(senderSquare);
    	}
    
    	private void Form1_Load(object sender, EventArgs e)
    	{
    		centerSquare.Click += new EventHandler(square_Click);
    		centerSquare.Size = new System.Drawing.Size(50, 50);
    		centerSquare.BackColor = Color.Red;
    		this.Controls.Add(centerSquare);
    	}
    }
