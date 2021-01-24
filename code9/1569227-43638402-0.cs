    public DelegateCommand<object> OnBtnSelect { get; private set; }
    
    public void OnSelect(object args)
    {
        //If your binding is correct args should contains the payload of the event
    }
    //In the ctor
    OnBtnSelect = new DelegateCommand<object>(OnSelect);
