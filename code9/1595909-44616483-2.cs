    public partial class ToothChart : UserControl
    {
        public ToothChart()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.ParentForm != null)
            {
                this.ParentForm.FormClosing += (s, evt) => { OnHandleDestroyed(new EventArgs()); };
            }
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            if (this._pathTop != null)
            {
                this._pathTop.Dispose();
                this._pathTop = null;
            }
            if (this._pathRight != null)
            {
                this._pathRight.Dispose();
                this._pathRight = null;
            }
            if (this._pathBottom != null)
            {
                this._pathBottom.Dispose();
                this._pathBottom = null;
            }
            if (this._pathLeft != null)
            {
                this._pathLeft.Dispose();
                this._pathLeft = null;
            }
            if (this._pathCenter != null)
            {
                this._pathCenter.Dispose();
                this._pathCenter = null;
            }
        }
        private GraphicsPath _pathTop = null;
        private GraphicsPath _pathLeft = null;
        private GraphicsPath _pathBottom = null;
        private GraphicsPath _pathRight = null;
        private GraphicsPath _pathCenter = null;
        private bool _TopRegion = false;
        public bool TopRegion
        {
            get
            {
                return _TopRegion;
            }
            set
            {
                if (_TopRegion != value)
                {
                    _TopRegion = value;
                    this.Invalidate();
                }
            }
        }
        private bool _RightRegion = false;
        public bool RightRegion
        {
            get
            {
                return _RightRegion;
            }
            set
            {
                if (_RightRegion != value)
                {
                    _RightRegion = value;
                    this.Invalidate();
                }
            }
        }
        private bool _BottomRegion = false;
        public bool BottomRegion
        {
            get
            {
                return _BottomRegion;
            }
            set
            {
                if (_BottomRegion != value)
                {
                    _BottomRegion = value;
                    this.Invalidate();
                }
            }
        }
        private bool _LeftRegion = false;
        public bool LeftRegion
        {
            get
            {
                return _LeftRegion;
            }
            set
            {
                if (_LeftRegion != value)
                {
                    _LeftRegion = value;
                    this.Invalidate();
                }
            }
        }
        private bool _CenterRegion = false;
        public bool CenterRegion
        {
            get
            {
                return _CenterRegion;
            }
            set
            {
                if (_CenterRegion != value)
                {
                    _CenterRegion = value;
                    this.Invalidate();
                }
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (this.IsHandleCreated && this._pathTop != null)
            {
                this.UpdateRegions();
            }
        }
        private void UpdateRegions()
        {
            int diameterBig = Math.Min(this.Width, this.Height) - 10;
            int diameterSmall = Math.Min(this.Width, this.Height) / 3;
            if (diameterBig > 0 && diameterSmall > 0)
            {
                Point _centerPoint = new Point(this.Width / 2, this.Height / 2);
                Rectangle rectangle = new Rectangle(_centerPoint.X - diameterBig / 2, _centerPoint.Y - diameterBig / 2, diameterBig, diameterBig);
                Rectangle rectangle2 = new Rectangle(_centerPoint.X - diameterSmall / 2, _centerPoint.Y - diameterSmall / 2, diameterSmall, diameterSmall);
                _pathTop.Reset();
                _pathTop.AddArc(rectangle, 225, 90);
                _pathTop.AddArc(rectangle2, -45, -90);
                _pathLeft.Reset();
                _pathLeft.AddArc(rectangle, 135, 90);
                _pathLeft.AddArc(rectangle2, -135, -90);
                _pathBottom.Reset();
                _pathBottom.AddArc(rectangle, 45, 90);
                _pathBottom.AddArc(rectangle2, -225, -90);
                _pathRight.Reset();
                _pathRight.AddArc(rectangle, -45, 90);
                _pathRight.AddArc(rectangle2, -315, -90);
                _pathCenter.Reset();
                _pathCenter.AddEllipse(rectangle2);
                this.Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.IsHandleCreated)
            {
                if (this._pathTop == null)
                {
                    this._pathTop = new GraphicsPath();
                    this._pathRight = new GraphicsPath();
                    this._pathBottom = new GraphicsPath();
                    this._pathLeft = new GraphicsPath();
                    this._pathCenter = new GraphicsPath();
                    this.UpdateRegions();
                }
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                if (this.TopRegion)
                {
                    e.Graphics.FillPath(Brushes.Blue, _pathTop);
                }
                e.Graphics.DrawPath(Pens.Black, _pathTop);
                if (this.RightRegion)
                {
                    e.Graphics.FillPath(Brushes.DarkRed, _pathRight);
                }
                e.Graphics.DrawPath(Pens.Black, _pathRight);
                if (this.BottomRegion)
                {
                    e.Graphics.FillPath(Brushes.Teal, _pathBottom);
                }
                e.Graphics.DrawPath(Pens.Black, _pathBottom);
                if (this.LeftRegion)
                {
                    e.Graphics.FillPath(Brushes.Yellow, _pathLeft);
                }
                e.Graphics.DrawPath(Pens.Black, _pathLeft);
                if (this.CenterRegion)
                {
                    e.Graphics.FillPath(Brushes.LightGreen, _pathCenter);
                }
                e.Graphics.DrawPath(Pens.Black, _pathCenter);
            }         
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            Point p = new Point(e.X, e.Y);
            if (this._pathTop.IsVisible(p))
            {
                this.TopRegion = !this.TopRegion;
            }
            else if (this._pathRight.IsVisible(p))
            {
                this.RightRegion = !this.RightRegion;
            }
            else if (this._pathBottom.IsVisible(p))
            {
                this.BottomRegion = !this.BottomRegion;
            }
            else if (this._pathLeft.IsVisible(p))
            {
                this.LeftRegion = !this.LeftRegion;
            }
            else if (this._pathCenter.IsVisible(p))
            {
                this.CenterRegion = !this.CenterRegion;
            }
        }
    }
