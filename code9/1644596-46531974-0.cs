    public CustomControl()
    {
        this.InnerLabel = new Label();
        
        // add inner binding
        this.InnerLabel.SetBinding(Label. TextColorProperty, new Binding(nameof(InnerLabelTextColor), mode: BindingMode.OneWay, source: this));  
        this.Content = this.InnerLabel;
    }
