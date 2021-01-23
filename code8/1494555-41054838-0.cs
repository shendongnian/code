    public class CustomButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
           base.OnPaint(pevent); //Call base for creating default Button
    
           using (Pen pen = new Pen(Color.Red, 3)) //Create small Red Pen
           {
                //Create the area we want to draw. In this case we draw at the Button top right corner (because Android, iOS do this)
                Rectangle rectangle = new Rectangle(pevent.ClipRectangle.X + pevent.ClipRectangle.Width - 10, 0, 10, 10);
    
                pevent.Graphics.DrawEllipse(pen, rectangle); //Draw a ellipse
                pevent.Graphics.FillEllipse(new SolidBrush(Color.Red), rectangle); //Fill this ellipse to be red
    
                    //Paint a string to the ellipse so that it looks like Android, iOS Notification
                    //You have to replace the 1 with dynamic count of your notifications
                 pevent.Graphics.DrawString("1", DefaultFont, new SolidBrush(Color.White), rectangle.X, rectangle.Y);
            }
        }
    }
