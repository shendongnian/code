        void Grid_DragLeave(object sender, DragEventArgs e)
        {
            var wizard = DataContext as WizardVM;
            var gd = sender as Grid;
            if (wizard == null || gd == null) return;
            Point pt = e.GetPosition(this);
            hitResults.Clear();
            VisualTreeHelper.HitTest(gd, null, GridHitTestResultCallback,
                new PointHitTestParameters(pt));
            if (!hitResults.Contains(gd))
            {
                wizard.Assembly.IsExpanded = false;
            }
        }
        HitTestResultBehavior GridHitTestResultCallback(HitTestResult result)
        {
            hitResults.Add(result.VisualHit);
            return HitTestResultBehavior.Continue;
        }
