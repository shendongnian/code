    private void UIElement_OnPreviewMouseMove(object sender, MouseEventArgs e)
        {
            Control c = (Control)sender;
            if (canmove) //field is used to define whether element dragged or not
            {
                c = (Control) sender;
                c.SetValue(Canvas.LeftProperty, e.GetPosition(Canvas).X - p.X);
                c.SetValue(Canvas.TopProperty, e.GetPosition(Canvas).Y - p.Y);
                var leftprop = Convert.ToDouble(c.GetValue(Canvas.LeftProperty));
                if (leftprop > Canvas.Width)
                    Canvas.Width = leftprop + c.Width+10;
               
            }
        }
