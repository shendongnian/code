    class Church
    {
        public int Id {get; set;}
        // every Church has zero or more Volunteers:
        public virtual ICollection<Volunteer> Volunteers {get; set;}
        // every Church hosts zero or more Appointments:
        public virtual ICollection <Appointment> Appointments {get; set;}
        ... // other Church properties
    }
    class Volunteer
    {
        public int Id {get; set;}
        // every Volunteer belongs to exactly one Church using foreign key
        public int ChurchId {get; set;}
        public virtual Church Church {get; set;}
        // every Volunteer has zero or more Appointments:
        public virtual ICollection<Appointment> Appointments {get; set;}
        ... // other Properties
    }
    class Appointment
    {
        public int Id {get; set;}
        
        // every Appointment is attended by one or more Volunteers (many-to-many)
        public virtual ICollection<Volunteer> Volunteers {get; set;}
        // every Appointment is hosted by exactly one Church using foreign key
        public int ChurchId {get; set;}
        public virtual Church Church {get; set;}
        ... // other properties
    }
    class MyDbContext : DbContext
    {
        public DbSet<Church> Churches {get; set;}
        public DbSet<Volunteer> Volunteers {get; set;}
        public DbSet<Appointment> Appointments {get; set;}
    }
