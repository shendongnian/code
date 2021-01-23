    public abstract class Window2<TViewModel> : Window {
        
        protected TViewModelViewModel {
            get { return (TViewModel)this.DataContext; }
        }
    }
