    public partial class MyDbContext
    {
        public IQueryable<Persons> FilteredPersons()
        {
            return this.Persons.Where(p => p.Forename =="David");
        }
    }
