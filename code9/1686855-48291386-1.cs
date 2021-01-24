	using System;
	using System.Drawing;
	using System.Windows.Forms;
	namespace StylesTest
	{
		public partial class Form1 : Form
		{
			public Form1()
			{
				InitializeComponent();
				Text = String.Empty;
				BackColor = Color.Black;
				ControlBox = false;
				FormBorderStyle = FormBorderStyle.FixedSingle;
			}
			protected override void WndProc(ref Message m)
			{
				const int WM_NCHITTEST = 0x0084;
				const int HTCLIENT  = 0x01;
				const int HTCAPTION = 0x02;
				base.WndProc(ref m);
				if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)
					m.Result = new IntPtr(HTCAPTION);
			}
		}
	}
