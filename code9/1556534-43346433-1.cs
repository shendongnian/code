    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace CustomForm
    {
    	public partial class CustomBorderForm : Form
    	{
    		public CustomBorderForm()
    		{
    			InitializeComponent();
    		}
    
    		protected override void OnPaint(PaintEventArgs e)
    		{
    			Rectangle borderRectangle = new Rectangle(1, 1, ClientRectangle.Width - 2, ClientRectangle.Height - 2);
    
    			e.Graphics.DrawRectangle(Pens.Blue, borderRectangle);
    			base.OnPaint(e);
    		}
    
    		private void button1_Click(object sender, EventArgs e)
    		{
    			this.Close();
    		}
    	}
    }
