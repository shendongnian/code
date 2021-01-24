    using System.Reflection;
    namespace IntersectLibrary
    {
      public abstract class Line
      {
        public string Intersect(Line line)
        {
          var method = this.GetType().GetRuntimeMethod(nameof(Intersect), new[] { line.GetType() });
          return (string)method.Invoke(this, new[] { line });
        }
        public abstract string Intersect(StraightLine straightLine);
        public abstract string Intersect(Circle circle);
      }
      public class StraightLine : Circle
      {
        public override string Intersect(StraightLine straightLine)
        {
          return "Straight line intersecting a straight line.";
        }
        public override string Intersect(Circle circle)
        {
          return "Straight line intersecting a circle.";
        }
      }
      public class Circle : Line
      {
        public override string Intersect(Circle circle)
        {
          return "Circle intersecting a circle.";
        }
        public override string Intersect(StraightLine straightLine)
        {
          return "Circle intersecting a straight line.";
        }
      }
    }
