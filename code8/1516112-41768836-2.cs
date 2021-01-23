        var xBind = new Binding();
        xBind.Source = this;
        xBind.Path = new PropertyPath(Thingy.LocationProperty);
        xBind.Mode = BindingMode.OneWay;
        xBind.Converter = new PointToDoubleConverter();
        xBind.ConverterParameter = false;
        BindingOperations.SetBinding(this, Canvas.LeftProperty, xBind);                
        var yBind = new Binding();
        yBind.Source = this;
        yBind.Path = new PropertyPath(Thingy.LocationProperty);
        yBind.Mode = BindingMode.OneWay;
        yBind.Converter = new PointToDoubleConverter();
        yBind.ConverterParameter = true;
        BindingOperations.SetBinding(this, Canvas.TopProperty, yBind); 
   
