    public class Person
    {
        //Event to register to, when you want to capture name changed of person
        public event EventHandler<NameChangedEventArgs> nameChangedEvent;
        //Property
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                this._name = value;
                //Call the event. This will trigger the OnNameChangedEvent_Handler
                OnNameChangedEvent_Handler(new NameChangedEventArgs() {NewName = value});
            }
        }
        private void OnNameChangedEvent_Handler(NameChangedEventArgs args)
        {
            //Check if event is null, if not, invoke it.
            nameChangedEvent?.Invoke(this, args);
        }
    }
    //Custom event arguments class. This is the argument type passed to your handler, that will contain the new values/changed values
    public class NameChangedEventArgs : EventArgs
    {
        public string NewName { get; set; }
    }
