      public class Color { }
      public class Shape { }
    
      public class Wheels
      {
        public Shape Shape { get; set; }
      }
    
      public class Doors
      {
        public Color Color { get; set; }
      }
    
      public class Car
      {
        public Doors Doors { get; set; }
        public Wheels Wheels { get; set; }
    
        public Car()
        {
          Doors = new Doors();
          Wheels = new Wheels();
        }
    
        public void PaintDoors(Color color)
        {
          Doors.Color = color;
        }
    
        public void ChangeWheelsShape(Shape shape)
        {
          Wheels.Shape = shape;
        }
      }
