    public abstract class MatrixTransformation2DBase : IMatrixTransformation2D
    {
        public Matrix3x3 TransformationMatrix { get; protected set; }
        public Vector2D Transform(Vector2D vector2Din)
        {
            return vector2Din*TransformationMatrix;
        }
    }
