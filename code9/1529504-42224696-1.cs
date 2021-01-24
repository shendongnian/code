    // Again the principal code, not real solution
    class DataClass
    {
        private int data;
        public void SetData(int value)
        {
            data = value; // Nobody knows this has happened
            // And now the others should be notified
            foreach (observer in observers)
            {
                observer.NotifyDataChanged();
            }
        }
    }
