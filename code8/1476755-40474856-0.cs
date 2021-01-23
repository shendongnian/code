    public class ViewModel {
        public Action ClickDelegate { get; set; }
        public ICommand ClickCommand {
            get { return new MvxCommand(() => {
                                // call the action method to start animation
                                ClickDelegate?.Invoke();
                             };
            }
        }
    }
    public class MyView {
    
        protected override OnCreate()  {
            // register delegate with VM
            ViewModel.ClickDelegate = () => { StartAnimation(); };
        } 
   
    }
