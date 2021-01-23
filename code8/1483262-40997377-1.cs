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
                var max = GetMax(padding);
                if (max < Height + Math.Abs(change)) {
                    return Height - max;
                }
            }
            else {
                var min = GetMin();
                if (min > padding - Math.Abs(change)) {
                    return padding - min;
                }
            }
            return change;
        }
        private int GetMax(int padding) {
            var max = int.MinValue;
            foreach (Control control in Controls) {
                var v = control.Top + control.Height + padding;
                if (v > max) {
                    max = v;
                }
            }
            return max;
        }
        private int GetMin() {
            var min = int.MaxValue;
            foreach (Control control in Controls) {
                if (control.Top < min) {
                    min = control.Top;
                }
            }
            return min;
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
