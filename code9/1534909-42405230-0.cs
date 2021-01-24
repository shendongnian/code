    public class Doc
    {
        public Doc()
        {
            _description = new CellContent();
           // subscribe to changes in child
            _description.PropertyChanged += DescriptionChanged; 
        }
        private void DescriptionChanged(object sender, PropertyChangedEventArgs e)
        {
            Debug.Write($"I'm a dirty dirty document. Property {e.PropertyName} has changed");
        }
        private CellContent _description;
        public CellContent Description
        {
            get
            {
                Debug.Write("I assure you this is called every time a getter of the child properties is called");
                return _description;
            }
            // If you have a setter, don't forget to -= unsubscribe and resubscribe += after changing
        }
    }
