	class MainForm : Form
	{
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == Program._id)
			{
				// do something
			}
			base.WndProc(ref m);
		}
	}
