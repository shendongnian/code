    Stock.FocusChange += (sender, e) =>
    {
        if (e.HasFocus)
        {
            Stock.SelectAll();
            var a = Stock.SelectionStart;
            var b = Stock.SelectionEnd;
            var text = Stock.Text.Substring(a, b);
        }
    };
