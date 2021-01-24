    public partial class Form1 : Form
        {
            private Button centerSquare = new Button();
            private Button topLeftSquare = new Button();
            private Button topRightSquare = new Button();
            private Button bottomLeftSquare = new Button();
            private Button bottomRightSquare = new Button();
            public Form1()
            {
                InitializeComponent();
            }
    
            private void square_Click(object sender, EventArgs e)
            {
                Split(sender as Button);
                centerSquare.Dispose();
            }
    
            private void topLeftSquare_Click(object sender, EventArgs e)
            {
                Split(sender as Button);
            }
    
            private void Split(Button source)
            {
                Button topRightSquare = new Button();
                Button bottomLeftSquare = new Button();
                Button bottomRightSquare = new Button();
    
                topLeftSquare.Click += new EventHandler(topLeftSquare_Click);
    
                int width = source.Height / 2;
    
                topLeftSquare.Size = new System.Drawing.Size(width,width);
                topRightSquare.Size = new System.Drawing.Size(width, width);
                bottomLeftSquare.Size = new System.Drawing.Size(width, width);
                bottomRightSquare.Size = new System.Drawing.Size(width, width);
    
                topLeftSquare.Location = new Point(0, 0);
                topRightSquare.Location = new Point(topLeftSquare.Width, 0);
                bottomLeftSquare.Location = new Point(0, topLeftSquare.Height);
                bottomRightSquare.Location = new Point(topLeftSquare.Width , topLeftSquare.Height );
    
                topLeftSquare.BackColor = Color.Red;
                topRightSquare.BackColor = Color.Red;
                bottomLeftSquare.BackColor = Color.Red;
                bottomRightSquare.BackColor = Color.Red;
    
                this.Controls.Add(topLeftSquare);
                this.Controls.Add(topRightSquare);
                this.Controls.Add(bottomLeftSquare);
                this.Controls.Add(bottomRightSquare);
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                centerSquare.Click += new EventHandler(square_Click);
                centerSquare.Size = new System.Drawing.Size(400, 400);
                centerSquare.BackColor = Color.Red;
                this.Controls.Add(centerSquare);
            }
    
        }
