    private void _model_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ModelClass.Foo))
        {
            Model = new ModelClass(Model);
        }
    }
