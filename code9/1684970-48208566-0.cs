	using System;
	using System.Windows.Forms;
	namespace SimpleFormsApplication
	{
		public partial class Form1 : Form
		{
			private readonly Random _random = new Random();
			public Form1()
			{
				InitializeComponent();
			}
			private void button_random_Click(object sender, EventArgs e)
			{
				int randomIndex = _random.Next(listBox1.Items.Count);
				var randomItem = listBox1.Items[randomIndex];
				MessageBox.Show($"Random item at index {randomIndex} is {randomItem}");
			}
		}
	}
