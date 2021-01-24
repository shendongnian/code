    public interface IGenerator
    {
        IMatrix Build();
    }
    public class GenericGenerator<TRow> : MatrixGeneratorBase, 
    IMatrixGenerator<GenericItemRow> where TRow : GenericItemRow
    {
            public IEnumerable<GenericItemRow> CreateCellValues()
        {
              //some logic here
        }
        public IMatrix Build()
        {
             BuildMatrixTemplate();
             GenericMatrix<TRow> _genericMatrix = new 
             GenericMatrix<TRow>();
              _genericMatrix = //Some logic here
              return _genericMatrix;
         }
    }
    public interface IMatrix
    {
      //Properties that you need to use.
    }
    
    public class GenericMatrix<T> : IMatrix  where T : GenericItemRow
    {
        public List<string> MatrixHeaders { set; get; }
        public List<T> MatrixRow { set; get; }
        public T MatrixFooterRow { set; get; }
    }
