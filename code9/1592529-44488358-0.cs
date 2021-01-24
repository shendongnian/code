	using System;
	using System.Drawing;
	using System.Windows.Forms;
	namespace WindowsFormsApp1
	{
		static class Program
		{
			[STAThread]
			static void Main()
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				var F = new Form
				{
					BackColor = Color.Black,
					TransparencyKey = Color.Black,
					Bounds = Screen.PrimaryScreen.Bounds,
					FormBorderStyle = FormBorderStyle.None,
				};
				var L = new Label
				{
					AutoSize = false,
					Text="Hello, World!",
					Dock = DockStyle.Fill,
					ForeColor = Color.White,
					Font = new Font("Consolas", 26),
					TextAlign = ContentAlignment.MiddleCenter
				};
				F.Controls.Add(L);
				Application.Run(F);
			}
		}
	}
