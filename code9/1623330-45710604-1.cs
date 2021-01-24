    private void MyBorder_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (MyBorder.ActualWidth > MyBorder.ActualHeight)
        {
            MyRectangle.Width = MyRectangle.Height = MyBorder.ActualHeight;
        }
        else if (MyBorder.ActualWidth < MyBorder.ActualHeight)
        {
            MyRectangle.Height = MyRectangle.Height = MyBorder.ActualWidth;
        }
    }
