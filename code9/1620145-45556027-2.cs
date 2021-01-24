    private bool _isSwiped;
    private void txtBox1_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
    {
        if (e.IsInertial && !_isSwiped)
        {
            var swipedDistance = e.Cumulative.Translation.X;
            if (Math.Abs(swipedDistance) <= 2) return;
            if (swipedDistance > 0)
            {
                i++;
            }
            else
            {
                i--;
            }
            txtBox1.Text = i.ToString();
            _isSwiped = true;
        }
    }
    private void txtBox1_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
    {
        _isSwiped = false;
    }
