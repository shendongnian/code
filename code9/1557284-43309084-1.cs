    private void LayoutRoot_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (hostVisual != null)
            {
                hostVisual.Size = new System.Numerics.Vector2((float)e.NewSize.Width, (float)e.NewSize.Height);
            }
        }
