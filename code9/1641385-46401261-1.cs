		private void Form1_Load(object sender, EventArgs e)
		{
			RoundButton _btn = new RoundButton();
			_btn.Text = "Log";
			_btn.Click += new EventHandler(_btnLog_Click);
			this.Controls.Add(_btn);
		}
		void _btnLog_Click(object sender, EventArgs e)
		{
			// do somethng here
		}
