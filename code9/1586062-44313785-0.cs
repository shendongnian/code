    public override Style SelectStyle(object item,
                DependencyObject container)
            {
                if (SetColor)
                {
                    Style st = new Style();
                    var _item = (item as CategoricalDataPoint);
                    st.TargetType = typeof(Border);
                    Setter backGroundSetter = new Setter();
                    backGroundSetter.Property = Border.BackgroundProperty;
    
                    if (_item.Value < 98)
                    {
                        backGroundSetter.Value = Brushes.Red;
                    }
                    else
                    {
                        backGroundSetter.Value = Brushes.Lime;
                    }
                    st.Setters.Add(backGroundSetter);
                    return st;
                }
                else
                    return null;
            }
