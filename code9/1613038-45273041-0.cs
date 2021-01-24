	using Microsoft.VisualBasic.PowerPacks;
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
			public Form1()
			{
				InitializeComponent();
			}
			private void button1_Click(object sender, EventArgs e)
			{
				string rectName;
				string rectBaseName = "rectangleShape";
				var shapeContainer = this.Controls.OfType<ShapeContainer>().FirstOrDefault();
				if (shapeContainer != null)
				{
					for (int i = 1; i <= 3; i++)
					{
						rectName = rectBaseName + i.ToString();
						RectangleShape match = shapeContainer.Shapes.OfType<RectangleShape>().FirstOrDefault(o => o.Name == rectName);
						if (match != null)
						{
							match.BackColor = Color.Red;
							match.BackStyle = BackStyle.Opaque;
						}
					}
				}      
			}
		}
	}
