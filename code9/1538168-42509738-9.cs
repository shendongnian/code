    public class MyWorker
    {
      // This would require that you setup Inversion of Control container and use it to resolve MyWorker.
      // See: http://stackoverflow.com/questions/1961549/resolving-ienumerablet-with-unity
      public MyWorker(IEnumerable<ILine> lines)
      {
         this.lines = lines;
      }
    }
