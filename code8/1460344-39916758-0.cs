      [Serializable()]
      [XmlRoot("shape", Namespace = "", IsNullable = false)]
      public abstract class Shape {
        public abstract void Draw();
        [XmlAttribute("name")] public string Name { get; set; }
      }
    
      [Serializable()]
      [XmlRoot("triangle", Namespace = "", IsNullable = false)]
      public class Triangle : Shape {
        public override void Draw() { }
      }
    
      [Serializable()]
      [XmlRoot("square", Namespace = "", IsNullable = false)]
      public class Square : Shape {
        public override void Draw() { }
      }
    
      [Serializable()]
      [XmlRoot("compositeShape", Namespace = "", IsNullable = false)]
      public class CompositeShape : Shape {
        [XmlElement("shape", typeof(Shape))]
        [XmlElement("triangle", typeof(Triangle))]
        [XmlElement("square", typeof(Square))]
        [XmlElement("compositeShape", typeof(CompositeShape))]
        public Shape[] Items { get; set; }
    
        public override void Draw() { }
      }
