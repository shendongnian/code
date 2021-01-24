    List<string> source =new List<string>();
		public Form1()
		{
			InitializeComponent();
			source.Add("a");
			source.Add("b");
			source.Add("c");
			source.Add("d");
			source.Add("e");
			SetButtonText(source);
		}
		private void SetButtonText(List<string> source)
		{
			button1.Text = source[0];
			button2.Text = source[1];
			button3.Text = source[2];
			button4.Text = source[3];
			button5.Text = source[4];
		}
		private void button1_Click(object sender, EventArgs e)
		{
			var rnd = new Random();
			var newsource = source.OrderBy(item => rnd.Next());
			SetButtonText(newsource.ToList());
		}
