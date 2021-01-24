    public interface IHit
    {
        IReadOnlyCollection<string> Result { get; }
    }
    
    public interface IHitService
    {
        IHit GetHit();
    }
       
    public class HitAdapter : IHit
    {
        private Hit _hit;
    
        public HitAdapter(Hit hit)
        {
            _hit = hit;
        }
    
        public IReadOnlyCollection<string> Result => _hit.Result;
    }
    
    
    public class TestingClass
    {
        public void MyTest()
        {
            var hitMock =  new Mock<IHit>();
            hitMock.Setup(c => c.Result).Returns<IReadOnlyCollection<string>>(x => new List<string>() {"hello", "goodbye"});
            var service = new Mock<IHitService>();
            service.Setup(c => c.GetHit()).Returns<IHit>(x => hitMock.Object);
        }
    }
    
   
