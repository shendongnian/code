    class StudentMap : ClassMap<Student> {
        public StudentMap() {
            Id(x => x.Id);
            Map(x => x.FirstName).Not.Nullable().Length(25);
            Map(x => x.SecondName).Nullable().Length(25);
            Map(x => x.LastName).Not.Nullable().Length(50);
            Map(x => x.PESEL).Nullable().Length(11);
            Map(x => x.BirthDate).Not.Nullable();
            Map(x => x.City).Not.Nullable().Length(50);
            Map(x => x.PostalCode).Nullable().Length(6);
            Map(x => x.Street).Not.Nullable().Length(50);
            Map(x => x.HouseNr).Not.Nullable().Length(10);
            Map(x => x.ApartmentNr).Nullable().Length(10);
            Map(x => x.PhoneNr).Nullable().Length(20);
            Map(x => x.Email).Nullable().Length(100);
    
            HasOne(x => x.DrivingLicense).PropertyRef(x => x.Student).Cascade.All();
            References(x => x.User).Unique().Not.Nullable();
            HasMany(x => x.Participants).Cascade.All();
        }
    }
    class DrivingLicenseMap : ClassMap<DrivingLicense> {
        public DrivingLicenseMap() {
            Id(x => x.Id);
            Map(x => x.IssueDate).Not.Nullable();
            Map(x => x.DrivingLicenseNr).Not.Nullable().Length(20);
    
            HasMany(x => x.DrivingLicensePermissions).Cascade.All();
            References(x => x.Student).Unique().Not.Nullable();
        }
    }
    class DrivingLicensePermissionsMap : ClassMap<DrivingLicensePermissions> {
        public DrivingLicensePermissionsMap() {
            Id(x => x.Id);
            Map(x => x.Category).Not.Nullable();
    
            References(x => x.DrivingLicense).Nullable();
        }
    }
