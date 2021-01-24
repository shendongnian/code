    public class ListEmulator : Collection<bool>
    {
        const bool IsPlannedDefault = false;  // Change to the appropriate values.
        const bool IsCompletedDefault = false;
        const bool IsRemainingDefault = false;
        const bool IsSerialDefault = false;
        void AddAllDefaults()
        {
            // Customize the code here to upgrade old collections with fewer than 4 elements to the current 4-element format.
            if (Count < 1)
                Add(IsPlannedDefault);
            if (Count < 2)
                Add(IsCompletedDefault);
            if (Count < 3)
                Add(IsRemainingDefault);
            if (Count < 4)
                Add(IsSerialDefault);
        }
        public ListEmulator() { }
        public ListEmulator(bool item0, bool item1, bool item2, bool item3)
        {
            this.IsPlanned = item0;
            this.IsCompleted = item1;
            this.IsRemaining = item2;
            this.IsSerial = item3;
        }
        public bool IsPlanned { get { return this.ElementAtOrDefault(0, IsPlannedDefault); } set { AddAllDefaults(); this[0] = value; } }
        public bool IsCompleted { get { return this.ElementAtOrDefault(1, IsCompletedDefault); } set { AddAllDefaults(); this[1] = value; } }
        public bool IsRemaining { get { return this.ElementAtOrDefault(2, IsRemainingDefault); } set { AddAllDefaults(); this[2] = value; } }
        public bool IsSerial { get { return this.ElementAtOrDefault(3, IsSerialDefault); } set { AddAllDefaults(); this[3] = value; } }
        protected override void InsertItem(int index, bool item)
        {
            if (index > 3)
                throw new ArgumentOutOfRangeException("index > 3");
            base.InsertItem(index, item);
        }
    }
