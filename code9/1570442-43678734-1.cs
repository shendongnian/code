    public class Sample
    {
        public void AddNewPerson(Person newPerson)
        {
            var personRepo = new Repository<Person>();
            personRepo.Insert(newPerson);
            personRepo.SaveChanges();
        }
    }
