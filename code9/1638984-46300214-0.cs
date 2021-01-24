    private static Style CreateStyle(string color)
    {
        var style = new Style(typeof(GridViewCell));
        var convertFromString = ColorConverter.ConvertFromString(color);
        if (convertFromString != null)
        {
            style.Setters.Add(new Setter(Control.BackgroundProperty,
                new SolidColorBrush((Color)convertFromString)));
        }
        else
        {
            Log.Warning("Unable to find a color for deal setting");
        }
        DataTrigger trigger = new DataTrigger
        {
            Value = true,
            Binding = new Binding
            {
                Path = new PropertyPath("IsChanged")
            }
        };
        var storyboard = new BeginStoryboard() { Name = "Highlight" }; //<--
        var sb = new Storyboard { Name = "Highlight" };
        storyboard.Storyboard = sb;
        style.RegisterName("Highlight", storyboard); //<---
        var colorAnimation = new ColorAnimation
        {
            Duration = new Duration(TimeSpan.FromSeconds(3)),
            From = System.Windows.Media.Colors.Red,
            FillBehavior = FillBehavior.Stop,
        };
        PropertyPath colorTargetPath = new PropertyPath("(Control.Background).(SolidColorBrush.Color)");
        Storyboard.SetTargetProperty(colorAnimation, colorTargetPath);
        var removeStoryboard = new RemoveStoryboard { BeginStoryboardName = "Highlight" };
        //  Storyboard.SetTargetProperty(removeStoryboard, colorTargetPath);
        sb.Children.Add(colorAnimation);
        trigger.EnterActions.Add(removeStoryboard);
        trigger.EnterActions.Add(storyboard);
        style.Triggers.Add(trigger);
        return style;
    }
