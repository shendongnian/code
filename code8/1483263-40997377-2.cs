    public class ScrollablePanel : Panel {
        private Point _mouseLastPosition;
        private bool _working;
        private readonly object _lock = new object();
        protected override void OnMouseDown(MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                _mouseLastPosition = e.Location;
            }
            base.OnMouseDown(e);
        }
        private int ValidateChange(int change) {
            const int padding = -1;
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
            for(var i=0;i<Controls.Count;i++) { 
                var v = Controls[i].Top + Controls[i].Height + padding;
                if (v > max) {
                    max = v;
                }
            }
            return max;
        }
        private int GetMin() {
            var min = int.MaxValue;
            for (var i = 0; i < Controls.Count; i++) {
                if (Controls[i].Top < min) {
                    min = Controls[i].Top;
                }
            }
            return min;
        }
        private void HandleDelta(int delta) {
            lock (_lock) {
                if (_working) {
                    return;
                }
                _working = true;
            }
            var change = ValidateChange(delta);
            for(var i=0; i<Controls.Count; i++) { 
                Controls[i].Top += change;
            }
            _working = false;
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
