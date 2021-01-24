    class Door : WorldItem
    {
        public void Unlock(string bitting)
        {
            if (bitting == "1234")
            {
                Console.WriteLine("Door Opened");
            }
            else
            {
                Console.WriteLine("Door could not unlock");
            }
        }
    }
    class DoorKey : ObtainableItem, IActsOn<Door>
    {
        private readonly string Bitting;
        public DoorKey(string bitting)
            : base("Key")
        {
            this.Bitting = bitting;
        }
        public void ApplyTo(Door worldItem)
        {
            worldItem.Unlock(this.Bitting);
        }
    }
    class RubberChicken : ObtainableItem
    {
        public RubberChicken()
            : base("Rubber chicken")
        {
        }
    }
