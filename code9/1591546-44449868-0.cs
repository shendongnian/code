    [TestMethod]
    public void TestMethod()
    {
        var groupId = "ABC";
        var personId = 1;
    
        ver personInfo = new PersonInfo()
        {
          Id = personId,
          FirstName = "Sam",
          LastName = "Smith"  `
        }
    
        var groupStub = new Mock<IGroupRepository>;
        groupStub.Setup(x=> x.GetById(groupId)).Returns(new Group(){
                Id = groupId,
                Persons = List<Person>()
                {
                    new Person()
                    {
                        Id = personId,
                        FirstName = "George",
                        LastName = "Bolton",
                    }
                }
            }
        });
    
        // var myClass = new MyClass();
        // myClass.Execute(personInfo, groupId);
    
        var group = groupStub.GetById(groupId);
        var person = group.Persons.First(p=> p.Id == personId);
    
        Assert.AreEqual(personInfo.FirstName, person.FirstName);
    }
