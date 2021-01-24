            Bag(x => x.Cars, map =>
            {
                map.Key(k => k.Column(col => col.Name("EngineId")));
                map.Cascade(Cascade.All | Cascade.DeleteOrphans); //optional
            },
                action => action.OneToMany());
