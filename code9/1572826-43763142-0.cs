    TEditorViewController TController;
    protected override void OnElementChanged(ElementChangedEventArgs<WysiwygEditor> e)
    {
        //Don´t call the base method here, since you want to create your own view.
        if (Control == null)
        {
           //Initialize TController
           TController = new TEditorViewController();
           //etc.
           SetNativeControl(TController.View);
        }
    }
