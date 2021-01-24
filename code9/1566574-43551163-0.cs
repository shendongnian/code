    using AsyncLoadingCollection.DTO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class PeopleService
    {
        private List<PersonDTO> _people;
        public PeopleService()
        {
            InitializePeople();
        }
        public async Task<IList<int>> GetIds()
        {
            // simulate async loading delay
            await Task.Delay(1000);
            var result = _people.Select(p => p.Id).ToList();
            return result;
        }
        public async Task<PersonDTO> GetPersonDetail(int id)
        {
            // simulate async loading delay
            await Task.Delay(3000);
            var person = _people.Where(p => p.Id == id).First();
            return person;
        }
        private void InitializePeople()
        {
            // poor person's database
            _people = new List<PersonDTO>();
            _people.Add(new PersonDTO { Name = "Homer", Age = 39, Id = 1 });
            _people.Add(new PersonDTO { Name = "Marge", Age = 37, Id = 2 });
            _people.Add(new PersonDTO { Name = "Bart", Age = 12, Id = 3 });
            _people.Add(new PersonDTO { Name = "Lisa", Age = 10, Id = 4 });
        }
    }
