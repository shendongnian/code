     public void OnScrollChange(NestedScrollView v, int scrollX, int scrollY, int oldScrollX, int oldScrollY)
        {
           
           if (scrollY == (v.GetChildAt(0).MeasuredHeight - v.MeasuredHeight))
            {
                SwitchToEventInfo(true);
            }
            else if (scrollY == 0)
            {
                SwitchToEventInfo(false);
            }
        }
