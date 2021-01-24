    public void TestGenericHelper()
    {
        //arrange
        using (var mock = AutoMock.GetLoose())
        {
    
            mock.Mock<IDAL>().Setup(x => x.GetMaturityConfiguration()).Returns("0=Child|13=Teen|18=Adult");
            mock.Mock<IDate>().Setup(x => x.Date).Returns(Convert.ToDateTime("2000-01-01"));
    
            var sut = mock.Create<GenericHelper>();
    
            String expected = "Teen";
    
            Person age = new Person();
            age.Birthdate = DateTime.Parse("1987-06-16");
    
            String actual = sut.CalculateMatruity(age);
    
            //assert
            mock.Mock<IDAL>().Verify(x => x.GetMaturityConfiguration());
            mock.Mock<IDate>().Verify(x => x.Date);
            Assert.Equal(expected, actual);
        }
    }
    
    public interface IDAL
    {
        string GetMaturityConfiguration();
    }
    
    public interface IAge
    {
        DateTime Birthdate { get; }
    }
    
    public interface IDate
    {
        DateTime Date { get; }
    
    }
    
    public class GenericHelper
    {
        private readonly IDAL dal;
        private readonly IDate dateHelper;
    
        public GenericHelper(IDAL dal, IDate dateHelper)
        {
            this.dal = dal;
            this.dateHelper = dateHelper;
        }
        public string CalculateMatruity(Person p)
        {
            // obviously not a real implementation
            var configuration = dal.GetMaturityConfiguration();
            var now = dateHelper.Date;
            return now > p.Birthdate ? "Teen" : "Fetus";
        }
    }
    
    public class Person
    {
        public DateTime Birthdate { get; set; }
    }
