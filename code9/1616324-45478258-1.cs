     protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           textBlock1.Text = ((Appbar_Sample.MyData)e.Parameter).LineOne;
            textBlock2.Text = ((Appbar_Sample.MyData)e.Parameter).LineTwo;
        }
