    public class ScrollablePanel : Panel {
        private Point _mouseLastPosition;
        protected override void OnMouseDown(MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                _mouseLastPosition = e.Location;
            }
            base.OnMouseDown(e);
        }
        private int ValidateChange(int change) {
            var padding = -1;
            if (change < 0) {
                var max = (from Control control in Controls select control.Top + control.Height + padding).Concat(new[] { int.MinValue }).Max();
                if (max < Height + Math.Abs(change)) {
                    return Height - max;
                }
            }
            else {
                var min = (from Control control in Controls select control.Top).Concat(new[] { int.MaxValue }).Min();
                if (min > padding - Math.Abs(change)) {
                    return padding - min;
                }
            }
            return change;
        }
        private void HandleDelta(int delta) {
            var change = ValidateChange(delta);
            foreach (Control control in Controls) {
                control.Top += change;
            }
            
        }
        protected override void OnMouseMove(MouseEventArgs e) {
            if((MouseButtons & MouseButtons.Left) != 0) { 
                var delta = e.Y - _mouseLastPosition.Y;
                HandleDelta(delta);
                _mouseLastPosition = e.Location;
            }
            base.OnMouseMove(e);
        }
        protected override void OnMouseWheel(MouseEventArgs e) {
            HandleDelta(e.Delta);
            base.OnMouseWheel(e);
        }
    }
