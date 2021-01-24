    Binding myBinding = new Binding();
     myBinding.Source = this.DataContext;
     myBinding.Path = new PropertyPath("Info");
     myBinding.Mode = BindingMode.TwoWay;
     myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
     BindingOperations.SetBinding(MyEditBox, CustomRichEditBox.CustomTextProperty, myBinding);
         
 
