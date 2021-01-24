    public class Transaction : INotifyPropertyChanged
    {
        //  ... stuff ...
        public Item Item
        {
            get { return _item; }
            set { 
                _item = value; 
                //  If this property is ever set outside the Transaction 
                //  constructor, you ABSOLUTELY MUST raise PropertyChanged here. 
                //  Otherwise, make the setter private. But just raise the event.
                //  This has nothing whatsoever to do with when or whether the Item 
                //  class raises PropertyChanged, because this is not a property of the 
                //  Item class. This is a property of Transaction. 
                NotifyPropertyChanged("Item");
            }
        }
        //  ... more stuff ...
