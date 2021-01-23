    public class Client : ISavingChanges
    {
        // other fields omitted for clarity...
        [ConcurrencyCheck]
        public long RowVersion { get; set; }
        public void OnSavingChanges()
        {
            RowVersion++;
        }
    }
