       public class CommandableCollectionItem<TItem, TViewModel>
                                where TViewModel : ICommandableNestedCollection<TItem>
        {
            public TItem Item { get; private set; }
            private readonly TViewModel _viewModel;
    
            public CommandableCollectionItem(TItem item, TViewModel viewModel)
            {
                this.Item = item;
                this._viewModel = viewModel;
            }
    
            public IMvxCommand Execute => new MvxCommand(() => _viewModel.OnExecute(Item));
    
        }
    public interface ICommandableNestedCollection<T>
        {
            void OnExecute<T>(T item);
        }
