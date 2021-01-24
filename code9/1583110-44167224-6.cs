    using (var fake = new AutoFake())
    {
    
        A.CallTo(() => fake.Resolve<IDAL>().GetMaturityConfiguration()).Returns("0=Child|13=Teen|18=Adult");
        A.CallTo(() => fake.Resolve<IDate>().Date).Returns(Convert.ToDateTime("2000-01-01"));
    
        var sut = fake.Resolve<GenericHelper>();
    
        String expected = "Teen";
    
        Person age = new Person();
        age.Birthdate = DateTime.Parse("1987-06-16");
    
        String actual = sut.CalculateMatruity(age);
    
        //assert
        A.CallTo(() => fake.Resolve<IDAL>().GetMaturityConfiguration()).MustHaveHappened();
        A.CallTo(() => fake.Resolve<IDate>().Date).MustHaveHappened();
        Assert.Equal(expected, actual);
    }
