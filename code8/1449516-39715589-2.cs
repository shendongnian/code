        [XmlRoot("FoodBasket")]
      public class myfruits
      {
        [XmlArray("MyFruits")]
        [XmlArrayItem(Type = typeof(apple)), XmlArrayItem(Type = typeof(orange))]
        public fruit[] fruits
        {
          get;
          set;
        }
    
        public myfruits (fruit[] _fruits)
        {
          fruits = _fruits;
        }
    
        public myfruits()
        {
          fruits = new fruit[] { };
        }
      }
    
      public abstract class fruit
      {
        [XmlElement("name")]
        public string name
        {
          get;
          set;
        }
    
        public fruit()
        {
          name = "none";
        }
      }
    
      public class apple : fruit
      {
        public int weight
        {
          get;
          set;
        }
    
        public apple()
        {
          name = "apple";
          weight = 2;
        }
      }
    
      public class orange : fruit
      {
        public string color
        {
          get;
          set;
        }
    
        public orange()
        {
          name = "orange";
          color = "redish-pink";
        }
      }
