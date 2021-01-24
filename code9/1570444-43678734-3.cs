    public class Sample
    {
        public void AddNewPerson(Person newPerson)
        {
            var personRepo = new Repository<Person>();
            personRepo.Insert(newPerson);
            personRepo.SaveChanges();
        }
        public void DeletePerson(int personId)
        {
            var personRepo = new Repository<Person>();
            Person person= personRepo.Find(p => p.Id == personId).SingleOrDefault();
            personRepo.Delete(person);
        }
    }
