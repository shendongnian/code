        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button != MouseButtons.Left) return;
            var dx = e.X - _mouseDownPoint.X;
            var dy = e.Y - _mouseDownPoint.Y;
            if (Math.Abs(dx) > SystemInformation.DoubleClickSize.Width || Math.Abs(dy) > SystemInformation.DoubleClickSize.Height)
            {
                DoDragDrop(this, DragDropEffects.Move);
            }
        }
