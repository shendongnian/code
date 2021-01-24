    public interface IFigures
    {
      int getarea();
    }
    public abstract class Figures : IFigures
    {
      public abstract int getarea();
    
      //opportunity for code reuse
      protected int getarea_internal()
      {
        throw new NotimplementedExcpetion();
      }
    }
    
    public class Square : Figures
    public class Rectangle: Figures
