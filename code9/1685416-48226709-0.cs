    public FirstClass : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        // Other properties
    }
    
    var otherClass = ...;
    realm.Write(() =>
    {
        realm.Add(otherClass, update: true);
    });
