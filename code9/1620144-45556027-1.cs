    private void scrollview_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
    {
        if (e.IsInertial)
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
        }
    }
