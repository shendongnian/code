    void datagridbatch_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var binding = BindingOperations.GetBindingExpression(input2, TextBox.TextProperty);
        if (binding != null)
        {
            binding.UpdateTarget();
        }
    }
