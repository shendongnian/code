            var peopleCollection = peopleArray.GroupBy(p => new { p.age, p.firstname, p.lastname }).Select(grp => grp.FirstOrDefault()).ToList();
            var finalists = new People[10];
            var rand = new Random();
            for (var i = 0; i < finalists.Length; i++)
            {
                var index = rand.Next(0, peopleCollection.Count);
                var person = peopleCollection[index];
                finalists[i].lastname = person.lastname;
                finalists[i].firstname = person.firstname;
                finalists[i].age = person.age;
                
                peopleCollection.Remove(person);
            }
