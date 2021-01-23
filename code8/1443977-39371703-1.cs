        protected override void OnRender(DrawingContext drawingContext)
        {
            // VM contains data of the grid, used to draw gridlines
            // such as number of days etc.
            if (this.VM == null)
            {
                base.OnRender(drawingContext);
                return;
            }
            double dpiFactor = 1;
            try
            {
                Matrix m = PresentationSource.FromVisual(this)
                         .CompositionTarget.TransformToDevice;
                dpiFactor = 1 / m.M11;
            }
            catch { }
            Pen pen = new Pen(Brushes.Black, 1 * dpiFactor);
            double halfPenWidth = pen.Thickness / 2;
            GuidelineSet guidelines = new GuidelineSet();
            double width = this.VM.Days.Count * this.VM.DayWidth - 16 * (this.VM.DayWidth / 24);
            double height = this.VM.RowHeight * rowCount;
            for (int i = 1; i < this.VM.Days.Count; i++)
            {
                guidelines.GuidelinesX.Add(i * this.VM.DayWidth + halfDashPenWidth);
            }
            for (int i = 1; i < rowCount; i++)
            {
                guidelines.GuidelinesY.Add(i * this.VM.RowHeight + halfPenWidth);
            }
            drawingContext.PushGuidelineSet(guidelines);
            for (int i = 1; i < this.VM.Days.Count; i++)
            {
                drawingContext.DrawLine(dashpen, new Point(i * this.VM.DayWidth, 0), new Point(i * this.VM.DayWidth, height));
            }
            for (int i = 1; i < rowCount; i++)
            {
                drawingContext.DrawLine(pen, new Point(0, i * this.VM.RowHeight), new Point(width, i * this.VM.RowHeight));
            }
            drawingContext.Pop();
        }
