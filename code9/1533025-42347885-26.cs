    #region Model Property
    private ModelClass _model = null;
    public ModelClass Model
    {
        get { return _model; }
        set
        {
            if (value != _model)
            {
                if (_model != null)
                {
                    _model.PropertyChanged -= _model_PropertyChanged;
                }
                _model = value;
                if (_model != null)
                {
                    _model.PropertyChanged += _model_PropertyChanged;
                }
                OnPropertyChanged();
            }
        }
    }
    private void _model_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        //  If Model.Foo changed, announce that Model changed. Any binding using 
        //  the Model property as its source will update, and that will cause 
        //  the template selector to be re-invoked. 
        if (e.PropertyName == nameof(ModelClass.Foo))
        {
            OnPropertyChanged(nameof(Model));
        }
    }
