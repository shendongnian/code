    public IDialogWithResult<TViewModel, TSomeReturnType> DialogWithResult<TViewModel,TSomeReturnType>(object owner = null)
            where TViewModel : DialogResultBase<TSomeReturnType>
    
    public IDialogWithResult<TViewModel> DialogWithResult<TViewModel>(object owner = null)
            where TViewModel : DialogResultBase<MyReturnType>
