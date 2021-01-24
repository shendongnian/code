    A.CallTo(() => this.personRepository.DeletePersons(
                        commonParam, 
                        A<IEnumerable<int>>.That.Matches(ids => ids.Single() == personId), 
                        false))
     .MustHaveHappened(Repeated.Exactly.Once);
