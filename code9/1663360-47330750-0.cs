    private void Submit_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(MyTextBox.Text)) return;
        BindingExpression bindingExpression = 
            BindingOperations.GetBindingExpression(MyTextBox, TextBox.TextProperty);
        BindingExpressionBase bindingExpressionBase =
            BindingOperations.GetBindingExpressionBase(MyTextBox, TextBox.TextProperty);
        ValidationError validationError =
            new ValidationError(new ExceptionValidationRule(), bindingExpression);
        validationError.ErrorContent = "My error message.";
        Validation.MarkInvalid(bindingExpressionBase, validationError);
    }
