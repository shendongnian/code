    while (HitTest(1, dayTop).HitArea != HitArea.Nowhere &&
           HitTest(1, dayTop).HitArea != HitArea.Date &&
           HitTest(1, dayTop).HitArea != HitArea.PrevMonthDate)
    {
        dayTop++;
    }
    while (HitTest(1, dayTop).HitArea != HitArea.Nowhere &&
           HitTest(1, bottom).HitArea != HitArea.Date &&
           HitTest(1, bottom).HitArea != HitArea.NextMonthDate)
    {
        bottom--;
    }
