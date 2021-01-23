    public class Transformer2D : MatrixTransformation2DBase
    {
        public Transformer2D(params IMatrixTransformation2D[] transformations)
        {
            for (int i = transformations.Length - 1; i >= 0; i--)
            {
                var matrixTransformation2D = transformations[i];
                if (TransformationMatrix != null)
                {
                    TransformationMatrix = TransformationMatrix * matrixTransformation2D.TransformationMatrix;
                }
                else
                {
                    TransformationMatrix = matrixTransformation2D.TransformationMatrix;
                }
            }
        }
    }
