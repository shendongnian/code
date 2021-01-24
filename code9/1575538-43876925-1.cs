        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (inDrag)
            {
                Point currentPoint = e.GetPosition(this);
                this.Left = this.Left + currentPoint.X - anchorPoint.X;
                /*this.Top = this.Top + currentPoint.Y - anchorPoint.Y*/; // this is not changing in your case
                anchorPoint = currentPoint;
            }
        }
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            if (inDrag)
            {
                ReleaseMouseCapture();
                inDrag = false;
                e.Handled = true;
            }
        }
