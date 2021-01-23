        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            if (EditingMode == InkCanvasEditingMode.Select)
            {
                var strokes = Strokes.Where(x => (x is CustomStroke) && ((CustomStroke)x).HitTestPoint(e.GetPosition(this))).ToList();
                if (strokes.Any())
                    Select(new StrokeCollection(strokes));
            }
            base.OnPreviewMouseDown(e);
        }
