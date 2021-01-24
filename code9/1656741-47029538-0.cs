    private int sec = 2;
    private async Task StartAnimation()
    {
        await StartAnimationForLabel1();
        await StartAnimationForLabel2();
    }
    private async Task StartAnimationForLabel1()
    {
        DoubleAnimation da1 = new DoubleAnimation()
        {
            From = 10,
            To = 200,
            Duration = new System.Windows.Duration(TimeSpan.FromSeconds(sec)),
        };
         ItemLabel1.BeginAnimation(Canvas.TopProperty, da1);
        await Task.Delay(sec * 1000); 
    }
    private async Task StartAnimationForLabel2()
    {
        DoubleAnimation da2 = new DoubleAnimation()
        {
            From = 300,
            To = 500,
            Duration = new System.Windows.Duration(TimeSpan.FromSeconds(sec)),
        };
        ItemLabels2.BeginAnimation(Canvas.LeftProperty, da2);
        await Task.Delay(sec * 1000);
    }
