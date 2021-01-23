    public class Class1 { 
    
        IMyService myService = new MyService();
    
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, myService.Add(2,2));
        }
    
    }
