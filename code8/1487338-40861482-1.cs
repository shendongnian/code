        private void myThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            double yadjust = graphicObjectViewBox.Height + e.VerticalChange;
            double xadjust = graphicObjectViewBox.Width + e.HorizontalChange;
            if ((xadjust >= 0) && (yadjust >= 0))
            {
                graphicObjectViewBox.Width = xadjust;
                graphicObjectViewBox.Height = yadjust;
                graphicObjectCanvas.Width = xadjust;
                graphicObjectCanvas.Height = yadjust;
                Width = (int)xadjust;
                Height = (int)yadjust;
                XapParent.Width = (int)xadjust;
                XapParent.Height = (int)yadjust;
                Canvas.SetLeft(myThumb, Canvas.GetLeft(myThumb) + e.HorizontalChange);
                Canvas.SetTop(myThumb, Canvas.GetTop(myThumb) + e.VerticalChange);
            }
        }
