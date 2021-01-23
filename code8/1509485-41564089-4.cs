    using Raven.Client;
    using Raven.Client.Indexes;
    using Raven.Tests.Helpers;
    using System;
    using System.Linq;
    using Xunit;
    
    namespace SO41547501Answer
    {
        public class SO41547501 : RavenTestBase
        {
            [Fact]
            public void SO41547501Test()
            {
                using (var server = GetNewServer())
                using (var store = NewRemoteDocumentStore(ravenDbServer: server))
                {
                    new CarIndex().Execute(store);
    
                    using (IDocumentSession session = store.OpenSession())
                    {
                        session.Store(new Person { Id = 1, Name = "A", Surname = "A" });
                        session.Store(new Car { Id = 1, Name = "A", PersonId = 1 });
                        session.Store(new Car { Id = 2, Name = "B", PersonId = 1 });
                        session.Store(new Car { Id = 3, Name = "C", PersonId = 2 });
                        session.SaveChanges();
                    }
    
                    WaitForAllRequestsToComplete(server);
                    WaitForIndexing(store);
    
                    using (IDocumentSession session = store.OpenSession())
                    {
                        var resultsForId1 = session
                            .Query<CarView, CarIndex>()
                            .ProjectFromIndexFieldsInto<CarView>()
                            .Where(x => x.PersonId == 1);
                        Assert.Equal(2, resultsForId1.Count());
                        var resultsForId2 = session
                            .Query<CarView, CarIndex>()
                            .ProjectFromIndexFieldsInto<CarView>()
                            .Where(x => x.PersonId == 2);
                        Assert.Equal(1, resultsForId2.Count());
                    }
    
                    using (IDocumentSession session = store.OpenSession())
                    {
                        server.Server.ResetNumberOfRequests();
                        var resultsForId1 = session
                            .Query<CarView, CarIndex>()
                            .ProjectFromIndexFieldsInto<CarView>()
                            .Where(x => x.PersonId == 1).Lazily();
                        var person = session.Advanced.Lazily.Load<Person>(1);
    
                        var personValue = person.Value;
                        var resultsValue = resultsForId1.Value;
                        Assert.Equal("A", personValue.Name); // person data loaded
                        Assert.Equal("A", resultsValue.First().Name); // cars data loaded
                        Assert.Equal(1, server.Server.NumberOfRequests); // only one request sent to the server
                    }
                }
            }
        }
    
        public class CarIndex : AbstractIndexCreationTask<Car, CarView>
        {
            public CarIndex()
            {
                Map = cars => from car in cars
                              select new
                              {
                                  car.Id,
                                  car.Name,
                                  car.PersonId,
                              };
            }
        }
    
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime? BirthDate { get; set; }
        }
    
        public class Car
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int PersonId { get; set; }
        }
    
        public class CarView
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int PersonId { get; set; }
        }
    }
