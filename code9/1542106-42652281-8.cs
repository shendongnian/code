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
                NotifyPropertyChanged("Item");
            }
        }
        //  ... more stuff ...
