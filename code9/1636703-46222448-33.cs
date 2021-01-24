            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (currentStroke.Count > 0)
            {
                if (cbx_Fill.Checked)
                    g.FillClosedCurve(b,  currentStroke.ToArray());
                else
                    g.DrawCurve(p, currentStroke.ToArray());
            }
            foreach (var stroke in strokes)
                if (stroke[0]==stroke[1])
                    g.FillClosedCurve(b,  stroke.ToArray());
                else
                    g.DrawCurve(p, stroke.ToArray());
