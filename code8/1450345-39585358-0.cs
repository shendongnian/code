    public class PatiantDetail {
        public string Name { get; set; }
    }
    public class DoctorDetail {
        public string Name { get; set; }
    }
    public interface IService {
        PatiantDetail GetPatiantDetail(int id);
        DoctorDetail GetDoctorDetail(string countryCode);
    }
    //System Under Test
    public class Sut
    {
        private readonly IService _myService;
        public Sut(IService service)
        {
            _myService = service;
        }
        public bool IsValid(int id)
        {
            var details = _myService.GetPatiantDetail(id); // This line should be avoided in test
            var doctorDetails = _myService.GetDoctorDetail("AUS"); // This needs to be executed
            if (details.Name == "Ab") // This if I don't want to be part of my test
            { // Do something 
            }
            if (doctorDetails != null)
            {// Code to test
            }
            return true;
        }
    }
    [TestClass]
    public class UnitTestClass
    {
        [TestMethod]
        public void TestMethodForDemostationOfStubbing()
        {
            //Qustion: "How to write tests that escapes or bypasses few methods and conditions inside a big method that is being tested"
            //Answer:
            //This is pivotal to Unit Testing as we should be able to isolate dependencies and test what is only reequired. 
            //As soon as we concern about calling real services/db, it becomes an Integration Test :)
            //There are many ways to do isolate dependencies in your test. For example, 
            //  a. Poor man's techniques. (too much code you may have to write)
            //  b. Using an isolation framework. i.e Rhyno Mock you already using. (less code you have to write)
            
            //Using your example
            //"I need only the second IF statement to be tested in my method."
            //Arrange
            int id = 3;
            var stubService = MockRepository.GenerateStub<IService>();
            stubService.Expect(x => x.GetPatiantDetail(Arg<int>.Is.Anything)).Return(new PatiantDetail() {Name = ""}); //so the first *if* statement get bypass. i.e not to return "Ab"
            //"I need to harcode the value of doctorDetails against to fetching its data from service as indicated above"
            stubService.Expect(x => x.GetDoctorDetail(Arg<string>.Is.Anything)).Return(new DoctorDetail()); //returns an object with any hard coded data so the second *if* statement get executed.
            var sut = new Sut(stubService);
            //Act
            var isValid = sut.IsValid(id);
            //Assert
            Assert.IsTrue(isValid);
        }
    }
