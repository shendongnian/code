    class PeopleService
        {
            public async Task<Person> GetPersonByIdAsync(int id)
            {
                Person randomPerson = await DataContext.People.FirstOrDefaultAsync(x => x.Id == id);
                return randomPerson;
            }
        }
