	public partial class Form1 : Form
	{
		private Warehouse warehouse1;
		private Warehouse warehouse2;
		public Form2()
		{
			InitializeComponent();
			warehouse1 = new Warehouse();
			warehouse2 = new Warehouse(6, 7, 8);
		}
		private void button1_Click(object sender, System.EventArgs e)
		{
			textBox1.Text = warehouse1.Radios.ToString();
			textBox2.Text = warehouse1.Televisions.ToString();
			textBox3.Text = warehouse1.Computers.ToString();
		}
		private void button2_Click(object sender, System.EventArgs e)
		{
			textBox1.Text = warehouse2.Radios.ToString();
			textBox2.Text = warehouse2.Televisions.ToString();
			textBox3.Text = warehouse2.Computers.ToString();
		}
	}
