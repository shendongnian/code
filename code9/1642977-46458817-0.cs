    static void SetRange(IWebElement e, double range)
    {
        int point = (int)(e.Size.Width * range);
        new Actions(Driver).MoveToElement(e, point, e.Size.Height / 2).Click().Build().Perform();
    }
