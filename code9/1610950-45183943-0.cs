        public class FirstViewModel 
        {
          public int MyProperty { get; set; }
        }
        public class SecondViewModel 
        {
          public string MySecondProperty { get; set; }
        }
        public class ThirdViewModel 
        {
          public DateTime MyThirdProperty { get; set; }
        }
        public class BagViewModel
        {
          public FirstViewModel FirstModel { get; set; }
          
          public SecondViewModel SecondModel { get; set; }
          public ThirdViewModel ThirdModel{ get; set; }
        }
