     private void Form1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
            {
                // If the MouseUp event occurs, the user is not dragging.
                isDrag = false;
    
                // Draw the rectangle to be evaluated. Set a dashed frame style 
                // using the FrameStyle enumeration.
                ControlPaint.DrawReversibleFrame(theRectangle, this.BackColor, FrameStyle.Dashed);
    
                // Find out which controls intersect the rectangle and 
                // change their color. The method uses the RectangleToScreen  
                // method to convert the Control's client coordinates 
                // to screen coordinates.
                Rectangle controlRectangle;
                for (int i = 0; i < Controls.Count; i++)
                {
                    controlRectangle = Controls[i].RectangleToScreen(Controls[i].ClientRectangle);
                    if (controlRectangle.IntersectsWith(theRectangle))
                    {
                        Controls[i].BackColor = Color.BurlyWood;
                    }
                }
    
                // Reset the rectangle.
                theRectangle = new Rectangle(0, 0, 0, 0);
            }
