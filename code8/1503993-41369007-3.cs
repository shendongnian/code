     public class MainViewModel
    {
        public ICommand OnRemoveClick { get; set; }        
        public MainViewModel()
        {
            OnRemoveClick = new DelegateCommand<Carrier>(RemoveCarrierFromNode);
        }
        public void RemoveCarrierFromNode(object obj)
        {
            CarrierList.Remove(obj);
        }
