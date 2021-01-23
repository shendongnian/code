    TextBlock SourceDependencyObject = new TextBlock();
    SourceDependencyObject.Text = "Hello";
    TextBlock TargetDependencyObject = new TextBlock();
    Binding myBinding = new Binding();
    myBinding.Source = SourceDependencyObject;
    myBinding.Path = new PropertyPath("Text");
    BindingOperations.SetBinding(TargetDependencyObject, TextBlock.TextProperty, myBinding);
    Debug.WriteLine(TargetDependencyObject.Text);
