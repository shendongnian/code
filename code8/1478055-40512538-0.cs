    var types = new List<Type>();
    types.Add(b.GetType());
    types.Add(c.GetType());
    foreach (var type in types)
    {
        if (type == typeof(Label))
        {
            ((Label)b).FontSize = 10;
            ((Label)b).Content = empIdNum;
        }
        else if (type == typeof(TextBox))
        {
            ((TextBox)b).FontSize = 10;
            ((TextBox)b).Text = empIdNum.ToString();
        }
        else if (type == typeof(TextBlock))
        {
            ((TextBlock)b).FontSize = 10;
            ((TextBlock)b).Text = empIdNum.ToString();
        }
    }
