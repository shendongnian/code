    A.CallTo(() => this.repository.Create(A<PersonModel>._)).ReturnsLazily(x =>
                {
                    var personModel = x.Arguments.Get<PersonModel>(0);
                    personModel.Name = "aName";
                    return personModel;
                });
