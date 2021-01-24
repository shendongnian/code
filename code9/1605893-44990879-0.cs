	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.IO;
	using System.Linq;
	using System.Runtime.InteropServices;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows.Forms;
	namespace WindowsFormsApp1
	{
		public partial class Form1 : Form
		{
			[DllImport("user32.dll")]
			static extern IntPtr GetForegroundWindow();
			[DllImport("user32.dll")]
			static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
			public Form1()
			{
				InitializeComponent();
			}
			private string GetActiveWindowTitle()
			{
				const int nChars = 256;
				StringBuilder Buff = new StringBuilder(nChars);
				IntPtr handle = GetForegroundWindow();
				if (GetWindowText(handle, Buff, nChars) > 0)
				{
					return Buff.ToString();
				}
				return null;
			}
			private void button1_Click(object sender, EventArgs e)
			{
				string title = GetActiveWindowTitle();
				label1.Text = title;
			}
		}
	}
