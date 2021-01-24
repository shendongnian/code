    namespace db_demo
    {
        using System;
        using System.ComponentModel.DataAnnotations;
        using System.Data.Entity;
    
        public class Data : DbContext
        {
            // Your context has been configured to use a 'Data' connection string from your application's
            // configuration file (App.config or Web.config). By default, this connection string targets the
            // 'db_demo.Data' database on your LocalDb instance.
            //
            // If you wish to target a different database and/or database provider, modify the 'Data'
            // connection string in the application configuration file.
            public Data()
                : base("name=Data")
            {
            }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
            }
    
            public virtual DbSet<KillEvent> KillEvents { get; set; }
        }
    
        [Serializable]
        public class KillEvent
        {
            [Key]
            public int KillEventId { get; set; }
    
            public float killerPosX { get; set; }
            public float killerPosY { get; set; }
            public float victimPosX { get; set; }
            public float victimPosY { get; set; }
            public string killerSide { get; set; }
            public string victimSide { get; set; }
            public string weaponType { get; set; }
    
            public override string ToString()
            {
                return String.Format("Id{0,6}: Side {1}, weapon {2}, pos ({3},{4}) victim  side {5} pos ({6},{7}) ",
                    KillEventId,
                    killerSide,
                    weaponType,
                    killerPosX,
                    killerPosY,
                    victimSide,
                    victimPosX, victimPosY
                    );
            }
        }
    }
