        public Style CorrectValueStyle
    {
        get
        {
            Style returnStyle = new Style(typeof(GridViewCell));
            returnStyle.Setters.Add(new Setter(GridViewCell.BorderBrushProperty, new SolidColorBrush(Colors.Black)));
            return returnStyle;
        }
        set
        {
        }
    }
