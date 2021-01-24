    public class ElementTransform
    {
        public MatrixTransform _previousTransform;
        public TransformGroup _transformGroup;
        public CompositeTransform _compositeTransform;
        public UIElement _ele;
        public ElementTransform(UIElement ele)
        {
            _transformGroup = new TransformGroup();
            _previousTransform = new MatrixTransform() { Matrix = Matrix.Identity };
            _compositeTransform = new CompositeTransform();
            _ele = ele;
            _transformGroup.Children.Add(_previousTransform);
            _transformGroup.Children.Add(_compositeTransform);
    
            ele.RenderTransform = this._transformGroup;
        }
    
    }
