    class Handler : 
        IHandleMessages<Events.Added>,
        IHandleMessages<Events.Removed>,
        IHandleQueries<Queries.ObjectsByName>
    {
        public void Handle(Events.Added e) {
           _orm.Add(new { ObjectId = e.ObjectId, Name = e.name });
        }
        public void Handle(Events.Removed e) {
           _orm.Remove(x => x.ObjectId == e.ObjectId && x.Name == e.Name);
        }
        public void Handle(Queries.ObjectsByName q) {
            _orm.Query(x => x.Name == q.Name);
        }
    }
