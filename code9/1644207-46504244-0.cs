    public class SportMap : ClassMapping<Sport>
        {
            public SportMap()
            {
                Id<Guid>(x => x.Id);
                Property<string>(x => x.Description);
                Bag(x => x.people, collectionMapping =>
                {
                    collectionMapping.Table("PersonSports");
                    //collectionMapping.Key(keyMapper => keyMapper.Column("SportId"));
                    collectionMapping.Cascade(Cascade.None);
                    collectionMapping.Key(k => k.Column("PersonId"));
                },
                map => map.ManyToMany(p => p.Column("SportId")));
            }
        }
    
        public class PersonSports
        {
            public virtual Guid SportId { get; set; }
            public virtual Guid PersonId { get; set; }
    
            public override bool Equals(object obj)
            {
                return true;
            }
    
            public override int GetHashCode()
            {
                return 1;
            }
        }
    
        public class PersonSportsMap : ClassMapping<PersonSports>
        {
            public PersonSportsMap()
            {
                ComposedId(map =>
                {
                    map.Property(x => x.PersonId);
                    map.Property(x => x.SportId);
                });
            }
        }
