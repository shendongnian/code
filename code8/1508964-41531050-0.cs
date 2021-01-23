	TextBox tb;
	
	public Form1()
	{
		InitializeComponent();
	}
	public void Form1_Load(object sender, EventArgs e)
	{
		tb = new TextBox();
		tb.Dock = System.Windows.Forms.DockStyle.Fill;
		tb.Location = new System.Drawing.Point(600, 430);
		tb.Multiline = true;
		panel2.Controls.Add(tb);
	}
	public void button1_Click(object sender, EventArgs e)
	{
		MessageBox.Show(tb.Text);
	}
