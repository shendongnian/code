    if (star.Value == RatingValue)
    {
        RatingValue = 0;
    }
    else
    {
        RatingValue = star.Value;
    }
                    
    BindingExpression binding = GetBindingExpression(RatingValueProperty);
    if (binding != null)
    {
        binding.UpdateSource();
    }
