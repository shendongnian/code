     public class MainViewModel
    {
        public ICommand OnRemoveClick { get; set; }        
        public MainViewModel()
        {
            OnRemoveClick = new DelegateCommand<string>(RemoveCarrierFromNode);
        }
        public void RemoveCarrierFromNode(object obj)
        {
            CarrierList.Remove(obj);
        }
