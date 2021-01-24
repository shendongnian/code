    public class Medicine_Incident
    {
        [SQLite.Net.Attributes.PrimaryKey, SQLite.Net.Attributes.AutoIncrement]
        public int Id { get; set; }
        public int IdMedicine { get; set; }
        [SQLite.Net.Attributes.Ignore]
        public Medicine Medicine { get; set; }
        public int IdUser_Profiles { get; set; }
        [SQLite.Net.Attributes.Ignore]
        public User_Profiles User_Profiles { get; set; }
        public DateTime Time { get; set; }
        public int Dosage { get; set; }
    
        public Medicine_Incident()
        {
            // (1/1/0001 12:00:00 AM)
            Dosage = 0;
        }
    }
