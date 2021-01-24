    using System;
    using System.Drawing;
    using System.Windows.Forms;
    namespace TestProjectWinforms
    {
        public partial class TrackBar : UserControl
        {
            private int _CurrentValue;
            private bool _IsDragging;
            private int _MaximumValue;
            private int _MinimumValue;
            public TrackBar()
            {
                InitializeComponent();
                TrackColor = Color.Red;
                TrackWidth = 10;
                MinimumValue = 0;
                MaximumValue = 10000;
                CurrentValue = 3000;
                HotTrackEnabled = true;
            }
            public event EventHandler CurrentValueChanged;
            public int CurrentValue
            {
                get => _CurrentValue;
                set
                {
                    _CurrentValue = value;
                    ValidateCurrentValue();
                    Invalidate();
                    RaiseEvent(CurrentValueChanged);
                }
            }
            public bool HotTrackEnabled { get; set; }
            public int MaximumValue
            {
                get => _MaximumValue;
                set
                {
                    _MaximumValue = value;
                    if (_MaximumValue < _MinimumValue)
                        _MaximumValue = _MinimumValue;
                    ValidateCurrentValue();
                    Invalidate();
                }
            }
            public int MinimumValue
            {
                get => _MinimumValue;
                set
                {
                    _MinimumValue = value;
                    if (_MinimumValue > _MaximumValue)
                        _MinimumValue = _MaximumValue;
                    ValidateCurrentValue();
                    Invalidate();
                }
            }
            public Color TrackColor { get; set; }
            public int TrackWidth { get; set; }
            protected override void OnMouseDown(MouseEventArgs e)
            {
                base.OnMouseDown(e);
                if (HotTrackEnabled)
                    _IsDragging = true;
            }
            protected override void OnMouseMove(MouseEventArgs e)
            {
                base.OnMouseMove(e);
                if (_IsDragging)
                {
                    UpdateCurrentValueFromPosition(e.X);
                    Invalidate();
                }
            }
            protected override void OnMouseUp(MouseEventArgs e)
            {
                base.OnMouseUp(e);
                _IsDragging = false;
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                using (var brush = new SolidBrush(TrackColor))
                {
                    e.Graphics.FillRectangle(brush, CreateRectangle());
                }
            }
            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);
                Invalidate();
            }
            private RectangleF CreateRectangle()
            {
                var position = GetRectanglePosition();
                var rectangle = new RectangleF(position, 0, TrackWidth, Height);
                return rectangle;
            }
            private float GetRectanglePosition()
            {
                var range = _MaximumValue - _MinimumValue;
                var value = _CurrentValue - _MinimumValue;
                var percentage = (float)value * 100 / range;
                var position = percentage * Width / 100;
                return position - (float)TrackWidth / 2;
            }
            private void RaiseEvent(EventHandler handler)
            {
                handler?.Invoke(this, EventArgs.Empty);
            }
            private void UpdateCurrentValueFromPosition(float x)
            {
                var percentage = x * 100 / Width;
                var range = _MaximumValue - _MinimumValue;
                var rawValue = percentage * range / 100;
                var value = rawValue + _MinimumValue;
                CurrentValue = (int)Math.Round(value);
            }
            private void ValidateCurrentValue()
            {
                if (_CurrentValue < _MinimumValue)
                    _CurrentValue = _MinimumValue;
                if (_CurrentValue > _MaximumValue)
                    _CurrentValue = _MaximumValue;
            }
        }
    }
