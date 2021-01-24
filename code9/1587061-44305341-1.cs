    public bool OnTouch(View v, MotionEvent e)
    {
        bool doubleClick = false;
        switch (e.Action)
        {
            case MotionEventActions.Down:
                saveClickPosition[0] = clickPosition[0];
                saveClickPosition[1] = clickPosition[1];
                clickPosition[0] = e.GetX();
                clickPosition[1] = e.GetY();
                doubleClick = toggleClick(clickPosition[0], clickPosition[1], saveClickPosition[0], saveClickPosition[1]);
                break;
        }
        if (v.GetType() == typeof(TextView) && doubleClick)
        {
            relMain.RemoveView(v);
            return true;
        }
        switch (v.Id)
        {
            case Resource.Id.relMain:
                if (doubleClick)
                {
                    relParams = new RelativeLayout.LayoutParams(300, 140);
                    relParams.LeftMargin = (int)clickPosition[0];
                    relParams.TopMargin = (int)clickPosition[1];
                    var tvwTest = new TextView(relMain.Context);
                    tvwTest.Text = string.Format("x: {0} y: {1}", clickPosition[0], clickPosition[1]);
                    tvwTest.SetOnTouchListener(this);
                    relMain.AddView(tvwTest, relParams);
                }                 
                break;
        }
        return true;
    }
