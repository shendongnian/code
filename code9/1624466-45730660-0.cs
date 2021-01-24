    public class GenericGenerator : MatrixGeneratorBase, IMatrixGenerator<GenericItemRow>
    {
        public object Build()
        {
             BuildMatrixTemplate();
             var genericMatrix = new GenericMatrix<GenericBudgetValueMatrixRow>();
             genericMatrix = //Some logic here
             return genericMatrix;
         }
    }
