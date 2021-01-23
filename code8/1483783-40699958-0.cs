        class BaseDTO { }
        class MessageDTO : BaseDTO { }
        interface IIncrementalLoadingHelper<out T> { }
    
        class ViewModelTestPage
        {
            IIncrementalLoadingHelper<BaseDTO> IncrementalLoadingHelper { get; }
    
            public ViewModelTestPage(IIncrementalLoadingHelper<MessageDTO> incrementalLoadingHelper)
            {
                IncrementalLoadingHelper = incrementalLoadingHelper;
            }
        }
