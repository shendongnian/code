    //Arrange
    var repo = Substitute.For<ISampleRepository>();
    var samples = new List<Sample>();
    samples.Add(new Sample(1)) // insert sample with id 1
    samples.Add(new Sample(2)) // insert sample with id 2
    
    repo.Get(Arg.Any<Expression<Func<Sample, bool>>>())
        .Returns(arg => {
            var predicate = arg.ArgAt<Expression<Func<Mitarbeiter, bool>>>(0).Compile();
            return samples.Where(predicate);            
        });
