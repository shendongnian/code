               BindingExpression be = textBox.GetBindingExpression(TextBox.TextProperty);
            Binding b = be?.ParentBinding as Binding;
            if (b != null)
            {
                Binding b2 = new Binding();
                b2.Path = b.Path;
                b2.Mode = BindingMode.OneWay;
                textBox.SetBinding(TextBox.TextProperty, b2);
            }
