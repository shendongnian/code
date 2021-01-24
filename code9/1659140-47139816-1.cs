    public static IDisposable BindSpinner<TView, TViewModel, TCommandProp, TSpinnerViewModel>(
                 this TView view,
                 TViewModel viewModel,
                 Expression<Func<TViewModel, TCommandProp>> viewModelCommandName,
                 Expression<Func<TViewModel, int>> viewModelSelectedPropertyName,
                 Expression<Func<TViewModel, IList<TSpinnerViewModel>>> viewModelSourceItemsName,
                 Expression<Func<TView, Spinner>> spinnerControl, Func<IList<TSpinnerViewModel>, ISpinnerAdapter> adapterFactory) where TViewModel : RxViewModel
                 where TCommandProp : ICommand
                 where TView : class, IViewFor<TViewModel>
                 where TSpinnerViewModel : class
            {
