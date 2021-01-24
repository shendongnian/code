    	private void GetAllControl(Control c, List<Control> list)
		{
			foreach (Control control in c.Controls)
			{
				list.Add(control);
				if (control.GetType() == typeof(Panel))
					GetAllControl(control, list);
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			List<Rectangle> btnLocation = new List<Rectangle>();
			List<Control> btnList = new List<Control>();
			GetAllControl(this, btnList);
			foreach (Control control in btnList)
			{
				if (control.Text != "Shuffle")
				{
					btnLocation.Add(control.Bounds);
				}
			}
			var rnd = new Random();
			var newsource = btnLocation.OrderBy(item => rnd.Next()).ToList();
			int i = 0;
			foreach (Control control in btnList)
			{
				if (control.Text != "Shuffle")
				{
					control.Bounds = newsource[i];
				}
				i++;
			}
		}
