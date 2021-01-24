    public class Player : IHaveStatus
    {
        private Status _status;
        public Status Status 
        {
            get {return _status;}
            set
            {
                // a player can't teleport...
                if(value != Status.Teleport)
                {
                    _status = value;
                }
            }
        }
    }
