    interface IView {
        void Close();
    }
    
    class ViewAdapter : IView {
        readonly Window view;
        public ViewAdapter(Window view){
            this.view = view;
        }
    
        public void Close() {
            view.Close();
        }
    }
    
    public class ProductionWindowFactory : IWindowFactory {
        public void CreateNewWindow() {
            var view = new PhoneWindow();
            var viewAdapter = new ViewAdapter(view)
            var viewModel = new phoneWindowViewModel(viewAdapter);
            
            //Bind
            view.DataContext = viewModel;
    
            view.Show();
        }
    }
