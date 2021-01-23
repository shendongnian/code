    public class ActionEventArgs : EventArgs
    {
        public ActionEventArgs(string valueName)
        {
            this.YourTypeValueName = valueName;
        }
        public YourType YourTypeValueName { get; set;}
    }
