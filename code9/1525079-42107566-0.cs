    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace DataGridViewCustomControls
    {
    	internal class DataGridViewHighlightChangeCell : DataGridViewTextBoxCell    
    	{
    		public Color HighlightColor { get; set; } = Color.Red;
    		public int HighlightTime { get; set; } = 1000;
    
    		private object PreviousValue;
    		private Color PreviousColor;
    		private Timer HighlightTimer = new Timer();
    
    		public DataGridViewHighlightChangeCell()
    		{
    			HighlightTimer.Tick += HighlightTimer_Tick;
    		}
    
    		protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
    		{
    			HighlightOnChange();
    
    			base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
    		}
    
    		private void HighlightOnChange()
    		{
    			if (RowIndex == -1 || Value == PreviousValue)
    			{
    				return;
    			}
    
    			PreviousValue = Value;
    
    			if (HighlightTimer.Enabled)
    			{
    				HighlightTimer.Stop();
    				HighlightTimer.Start();
    				return;
    			}
    
    			PreviousColor = Style.BackColor;
    			Style.BackColor = HighlightColor;
    			HighlightTimer.Interval = HighlightTime;
    			HighlightTimer.Start();
    		}
    
    		private void HighlightTimer_Tick(object sender, EventArgs e)
    		{
    			HighlightTimer.Stop();
    			Style.BackColor = PreviousColor;
    		}
    
    		protected override void Dispose(bool disposing)
    		{
    			if (disposing && HighlightTimer != null)
    			{
    				HighlightTimer.Dispose();
    				HighlightTimer = null;
    			}
    
    			base.Dispose(disposing);
    		}
    	}
    }
