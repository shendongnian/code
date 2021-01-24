    public class DeliveryMethod 
    {
        public int Id {get; set;}
        public bool IsSelectedDeliveryIconVisible {get; set;}
        // ...
    }
    DeliveryMethod _selectedDeliveryMethod;
    public DeliveryMethod SelectedDeliveryMethod
    {
        get { return _selectedDeliveryMethod; }
        set
        {
            SetProperty(ref _selectedDeliveryMethod, value);
            if (_selectedDeliveryMethod != null)
            {
                DeliveryMethodList.ForEach(d => { d.IsSelectedDeliveryIconVisible = (d.Id == value.Id); });
            }
        }
    }
