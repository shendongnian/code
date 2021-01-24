    foreach (var person in persons)
    	            {
                        if (!dictionaryPerson.ContainsKey(person.Id))
                        {
                            dictionaryPerson.Add(person.Id, new List<Person> { person });
                        }
                        else
                        {
                            dictionaryPerson[person.Id].Add(person);
                        }
    	            }
