	void Main()
	{
		var form = new MyForm();	
		form.Show();	
	}
	
	class MyForm : Form
	{
		private TextBox tb;
	
		public MyForm()
		{
			tb = new TextBox();	
			tb.Width = 300;
			this.Controls.Add(tb);
			
	
			var btn = new Button();
			btn.Text = "go";
			btn.Width = 300;		
			btn.Location = new System.Drawing.Point(0, 50);
			this.Controls.Add(btn);
	
			btn.Click += (sender, args) =>
			{
				tb.Text = string.Empty;
				var str = "alk;lfkdsfj;slfhjs;idjhf;lksdjf;klsdjf;'lkjds;lfksd";
				SetText d = SetTextToTb;
				Task.Run(() =>
				{
					foreach (var c in str.ToCharArray())
					{
						Thread.Sleep(100);
						tb.Invoke(d, c);
					}
				});
			};
		}
		
		public delegate void SetText(char text);
		void SetTextToTb(char text)
		{
			tb.Text += text;
		}
	}
	
