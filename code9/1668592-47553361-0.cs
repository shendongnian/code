    void CustomizedToolTip_Draw(object sender, DrawToolTipEventArgs e)
    {
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            myToolTipRectangle.Size = e.Bounds.Size;
            e.Graphics.FillRectangle(myBorderBrush, myToolTipRectangle);
            myImageRectangle = Rectangle.Inflate(myToolTipRectangle, 
    				-BORDER_THICKNESS, -BORDER_THICKNESS);
            e.Graphics.FillRectangle(myBackColorBrush, myImageRectangle);
            Control parent = e.AssociatedControl;
            Image toolTipImage = parent.Tag as Image; 
            if (toolTipImage != null)
            {
                myImageRectangle.Width = myInternalImageWidth;
                myTextRectangle = new Rectangle(myImageRectangle.Right, myImageRectangle.Top,
                (myToolTipRectangle.Width - myImageRectangle.Right - BORDER_THICKNESS), 
    						myImageRectangle.Height);
                myTextRectangle.Location = 
    		new Point(myImageRectangle.Right, myImageRectangle.Top);
                e.Graphics.FillRectangle(myBackColorBrush, myTextRectangle);
                e.Graphics.DrawImage(toolTipImage, myImageRectangle);
                e.Graphics.DrawString(e.ToolTipText, myFont, 
    			myTextBrush, myTextRectangle, myTextFormat);
            }
            else
            {
                e.Graphics.DrawString(e.ToolTipText, myFont, 
    			myTextBrush, myImageRectangle, myTextFormat);
            }
    }
