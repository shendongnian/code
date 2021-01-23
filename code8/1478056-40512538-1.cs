    var types = new List<Type>();
    types.Add(b.GetType());
    types.Add(c.GetType());
    foreach (var type in types)
    {
        if (typeof(Label).IsAssignableFrom(type))
        {
            ((Label)d).FontSize = 10;
            ((Label)d).Content = empIdNum;
        }
        else if (typeof(TextBox).IsAssignableFrom(type))
        {
            ((TextBox)d).FontSize = 10;
            ((TextBox)d).Text = empIdNum.ToString();
        }
        else if (typeof(TextBlock).IsAssignableFrom(type))
        {
            ((TextBlock)d).FontSize = 10;
            ((TextBlock)d).Text = empIdNum.ToString();
        }
    }
