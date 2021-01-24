    private void TextBox_ValidationErrorEventHandler(object sender, RoutedEventArgs e)
    {
        TextBox tb = sender as TextBox;
        if (tb != null)
        {
            DependencyProperty prop = TextBox.TextProperty;
            BindingExpression binding = BindingOperations.GetBindingExpression(tb, prop);
            if (binding != null)
            {
                binding.UpdateTarget();
                Validation.SetErrorTemplate(tb, null);
            }
        }
    }
