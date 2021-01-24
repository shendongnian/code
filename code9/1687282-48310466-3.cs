    public static class IntAggregator
    {
        public static void Transmit(int data)
        {
            if (OnDataTransmitted != null)
            {
                OnDataTransmitted(data);
            }
        }
        public static Action<int> OnDataTransmitted;
    }
