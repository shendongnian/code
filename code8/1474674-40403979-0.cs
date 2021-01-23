    public class Client : ISavingChanges
    {
        // other fields omitted for clarity...
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ConcurrencyCheck]
        public long RowVersion { get; set; }
        public void OnSavingChanges()
        {
            RowVersion++;
        }
    }
