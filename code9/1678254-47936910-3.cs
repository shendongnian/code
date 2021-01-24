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
        this.renderCanvas2 = new GLControl();
        this.renderCanvas2.BackColor = System.Drawing.Color.DeepSkyBlue;
        this.renderCanvas2.Location =
            new System.Drawing.Point(winX + 150, winY + 150);
        this.renderCanvas2.Name = "renderCanvas2";
        this.renderCanvas2.Size = 
            new System.Drawing.Size(winW / 2, winH / 2);
        this.renderCanvas2.TabIndex = 1;
        this.renderCanvas2.VSync = false;
        this.renderCanvas2.Load +=
            new System.EventHandler(this.renderCanvas2_Load);
        this.renderCanvas2.Paint +=
            new System.Windows.Forms.PaintEventHandler(
                this.renderCanvas2_Paint);
        this.Controls.Add(this.renderCanvas2);
    }
