    A.CallTo(() => this.personRepository.DeletePersons(
                    commonParam, 
                    A<IEnumerable<int>>.That.IsSameSequenceAs(personId), 
                    false))
     .MustHaveHappened(Repeated.Exactly.Once);
