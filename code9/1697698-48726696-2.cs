    public Uri FrameUri
    {
        get
        {
            return _frameUri;
        }
        set
        {
            if(Set(FrameUriPropertyName, ref _frameUri, value))
            {
                // assuming this is the command you are having trouble with
                // this will force the command to reevaluate CanExecute
                ChangeToLastPage.RaiseCanExecuteChanged();
            }
        }
    }
