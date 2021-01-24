    using...
    namespace Draw3Dv01wf
	{
	    public partial class Form1 : Form
	    {
	        GLControl[] renderCanvas = new GLControl[10];
	        private int 
	            winX, winY, winW, winH, winDist, winNum, 
	            aCol, rCol, gCol, bCol;
	        Random randNum = new Random();
	        //byte[] num = new byte[255];
	        byte r, g, b, a;
	        Color4 winCol;
	        private bool winCreated;
	        private bool eHandlerIs;
	
	        TextBox tb = new TextBox();
	
	        public Form1()
	        {
	            // required method for designer support
	            InitializeComponent();
	            initSetup();
	        }
	
	        private void initSetup()
	        {
	            winX = this.Location.X; winY = this.Location.Y;
	            winW = this.Width; winH = this.Height;
	            rCol = 255; gCol = 255; bCol = 255; aCol = 255;
	
	            // debugging text
	            tb.Location = new Point(5, 5);
	            tb.Size = new Size(200, 15);
	            tb.Name = "textBox1";
	            tb.TabIndex = 0;
	            tb.BackColor = Color.Black;
	            tb.ForeColor = Color.White;
	            tb.Text = winNum.ToString();
	            this.Controls.Add(this.tb);
	
	            // create windows
	            for (int w=0; w<8; w++)
	            {
	                // window distance 
	                winDist += 32;
	                // make sure window with index 0 is created
	                if (winCreated) { winNum += 1; }
	
	                // create windows 
	                this.renderCanvas[w] = new GLControl();
	                //this.SuspendLayout();
	                this.renderCanvas[w].BackColor = 
	                    System.Drawing.Color.DeepSkyBlue;
	                this.renderCanvas[w].Location =
	                    new System.Drawing.Point(winX + winDist, winY + winDist);
	                this.renderCanvas[w].Name = "renderCanvas" + w;
	                this.renderCanvas[w].Size =
	                    new System.Drawing.Size(winW / 2, winH / 2);
	                this.renderCanvas[w].TabIndex = 1;
	                this.renderCanvas[w].VSync = false;
	                // create event handler 
	                this.renderCanvas[w].Load +=
	                    new System.EventHandler(this.renderCanvas_Load);
	                if (!eHandlerIs)
	                {
	                    this.renderCanvas[w].Paint +=
	                        new System.Windows.Forms.PaintEventHandler(
	                            this.renderCanvas_Paint);
	                    //eHandlerIs = true;
	                }
	                //this.ResumeLayout(false);
	
	                // add specified control to the control collection 
	                this.Controls.Add(this.renderCanvas[w]);
	                winCreated = true; // first window created
	            }
	        }
	
	        private void renderCanvas_Paint(object sender, PaintEventArgs e)
	        {
	            tb.Text = r.ToString();
	            if (winNum < 7)
	            {
	                //GL.Viewport(
	                //    renderCanvas[winNum].Location.X,
	                //    renderCanvas[winNum].Location.Y, Width, Height);
	
	                //// Clear the render canvas with the current color
	                //GL.Clear(
	                //    ClearBufferMask.ColorBufferBit |
	                //    ClearBufferMask.DepthBufferBit);
	
	                //GL.Flush();
	                //renderCanvas[winNum].SwapBuffers();
	            }
	            else if (winNum >= 7)
	            {
	                for (int w = 0; w < 8; w++)
	                {
	                    GL.Viewport(
	                    renderCanvas[w].Location.X,
	                    renderCanvas[w].Location.Y, Width, Height);
	
	                    // Clear the render canvas with the current color
	                    GL.Clear(
	                        ClearBufferMask.ColorBufferBit |
	                        ClearBufferMask.DepthBufferBit);
	
	                    GL.Flush();
	                    renderCanvas[w].SwapBuffers();
	                }
	            }
	        }
	
	        private void renderCanvas_Load(object sender, EventArgs e)
	        {
	            // randomize color (min & max int)
	            rCol = randNum.Next(100, 255);
	            gCol = randNum.Next(100, 255);
	            bCol = randNum.Next(100, 255);
	            aCol = 255;
	            // convert int to (32) byte
	            r = (byte)(rCol >> 32);
	            g = (byte)(gCol >> 32);
	            b = (byte)(bCol >> 32);
	            a = (byte)(aCol >> 32);
	            // window final color
	            winCol = new Color4(r, g, b, a);
	
	            // Specify the color for clearing
	            GL.ClearColor(winCol);
	        }
	    }
	}
	
