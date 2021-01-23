    class Pump
    {
        public event EventHandler<PumpEventArgs> StatusChanged;
        private System.Timers.Timer timer;
        private Vehicle vehicle;
    
        public Pump(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("The name for the pump is not valid. It cannot be null or empty.");
            }
    
            this.Name = name;
    
            this.timer = new System.Timers.Timer();
            this.timer.Elapsed += Timer_Elapsed;
            this.timer.Interval = 100;
            this.timer.AutoReset = true;
        }
    
        public string Name { get; private set; }
    
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // If the pump is not occupied, we do nothing
            if (!this.IsOccupied)
            {
                return;
            }
    
            // Looks like the pump was occupied and
            // the timer went off so lets make the pump available by setting the
            // vehicle at this pump to null
            this.Vehicle = null;
        }
    
        // Private set so the only way to set this is to call the start method
        public Vehicle Vehicle
        {
            get
            {
                return this.vehicle;
            }
            private set
            {
                this.vehicle = value;
                if (value == null)
                {
                    this.IsOccupied = false;
                }
                else
                {
                    this.IsOccupied = true;
                }
    
                // If anyone has subscribed to the pump change event, notify them and send them the status
                if (this.StatusChanged != null)
                {
                    this.StatusChanged(this, new PumpEventArgs { Status = this.Status });
                }
            }
        }
    
        // private set so the only way a pump is occupied if start has been called.
        // Other classes should not be able to set IsOccupied to false if there is a vehicle at the 
        // pump.
        public bool IsOccupied { get; private set; }
    
        // This is a read-only property. It depends on the status.
        public string Status
        {
            get
            {
                if (this.IsOccupied)
                {
                    return "Occupied";
                }
    
                return "Free";
            }
        }
    
        public void Start(Vehicle vehicle)
        {
            // This object should take care of its own rules. If someone calls Start
            // and the pump is busy and they call start again, do not allow it.
            if (this.IsOccupied)
            {
                throw new InvalidOperationException("This pump is already occupied.");
            }
    
            // Set using property so the property can carry out the other rules
            this.Vehicle = vehicle;
    
            // Start the pump timer as well
            this.timer.Start();
        }
    }
