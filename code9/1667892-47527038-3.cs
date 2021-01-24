    public class ElementTransform
    {
        public MatrixTransform _previousTransform;
        public TransformGroup _transformGroup;
        public CompositeTransform _compositeTransform;
    
        public ElementTransform()
        {
            _transformGroup = new TransformGroup();
            _previousTransform = new MatrixTransform() { Matrix = Matrix.Identity };
            _compositeTransform = new CompositeTransform();
            _transformGroup.Children.Add(_previousTransform);
            _transformGroup.Children.Add(_compositeTransform);   
        }
    
    }
    
