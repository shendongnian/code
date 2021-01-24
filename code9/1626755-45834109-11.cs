    public override bool OnTouchEvent(MotionEvent e)
    {
        float x = e.GetX();
        float y = e.GetY();
        int width = this.MeasuredWidth;
        PointF point1Draw;
        PointF point2Draw;
        PointF point3Draw;
        if (this._direction == TriangularButtonDirection.Up)
        {
            point1Draw = new PointF(0, 3f * width / 4);
            point2Draw = new PointF(width, 3f * width / 4);
            point3Draw = new PointF(width / 2f, 0);
        }
        else
        {
            point1Draw = new PointF(0, 0);
            point2Draw = new PointF(width, 0);
            point3Draw = new PointF(width / 2f, 3f * width / 4);
        }
    
        bool test = PointInTriangle(new PointF(x, y), point1Draw, point2Draw, point3Draw);
        if (test)
            base.OnTouchEvent(e);
    
        switch (e.Action)
        {
            case MotionEventActions.Down:
                mstate = state.pressed;
                this.Invalidate();
                break;
    
            case MotionEventActions.HoverEnter:
                mstate = state.hovered;
                this.Invalidate();
                break;
    
            case MotionEventActions.Up:
                mstate = state.normal;
                this.Invalidate();
                break;
    
            case MotionEventActions.HoverExit:
                mstate = state.normal;
                this.Invalidate();
                break;
        }
    
        return (test);
    }
    
    private state mstate = state.normal;
    
    private enum state
    {
        normal,
        pressed,
        hovered
    }
    
    public static bool PointInTriangle(PointF p, PointF p0, PointF p1, PointF p2)
    {
        float s = p0.Y * p2.X - p0.X * p2.Y + (p2.Y - p0.Y) * p.X + (p0.X - p2.X) * p.Y;
        float t = p0.X * p1.Y - p0.Y * p1.X + (p0.Y - p1.Y) * p.X + (p1.X - p0.X) * p.Y;
        if ((s < 0) != (t < 0))
            return false;
        float a = -p1.Y * p2.X + p0.Y * (p2.X - p1.X) + p0.X * (p1.Y - p2.Y) + p1.X * p2.Y;
        if (a < 0.0)
        {
            s = -s;
            t = -t;
            a = -a;
        }
        return s > 0 && t > 0 && (s + t) <= a;
    }
    
    protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
    {
        base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
        this.SetMeasuredDimension(this.MeasuredWidth, 3 * this.MeasuredWidth / 4);
    }
    
    public override void Draw(Canvas canvas)
    {
        int width = this.MeasuredWidth;
        switch (mstate)
        {
            case state.normal:
                Paint paintFill = new Paint(PaintFlags.AntiAlias);
                paintFill.StrokeWidth = 2;
                paintFill.Color = this.Hovered ? Color.Red : new Color(242, 180, 54);
                paintFill.SetStyle(Android.Graphics.Paint.Style.Fill);
                paintFill.AntiAlias = true;
    
                Paint paintStroke = new Paint(PaintFlags.AntiAlias);
                paintStroke.StrokeWidth = 2;
                paintStroke.Color = Color.White;
                paintStroke.SetStyle(Android.Graphics.Paint.Style.Stroke);
                paintStroke.AntiAlias = true;
    
                PointF point1Draw;
                PointF point2Draw;
                PointF point3Draw;
                if (this._direction == TriangularButtonDirection.Up)
                {
                    point1Draw = new PointF(0, 3f * width / 4);
                    point2Draw = new PointF(width, 3f * width / 4);
                    point3Draw = new PointF(width / 2f, 0);
                }
                else
                {
                    point1Draw = new PointF(0, 0);
                    point2Draw = new PointF(width, 0);
                    point3Draw = new PointF(width / 2f, 3f * width / 4);
                }
    
                Path path = new Path();
                path.SetFillType(Path.FillType.EvenOdd);
                path.MoveTo(point1Draw.X, point1Draw.Y);
                path.LineTo(point2Draw.X, point2Draw.Y);
                path.LineTo(point3Draw.X, point3Draw.Y);
                path.LineTo(point1Draw.X, point1Draw.Y);
                path.Close();
    
                canvas.DrawPath(path, paintFill);
                canvas.DrawPath(path, paintStroke);
                break;
    
            case state.hovered:
                //TODO:
                break;
    
            case state.pressed:
                //TODO:
                break;
        }
    }
