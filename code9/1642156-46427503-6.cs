    public class ZoomOnMouseWheel : Behavior<FrameworkElement>
    {
        public Key? ModifierKey { get; set; } = null;
        public TransformMode TranformMode { get; set; } = TransformMode.Render;
        private Transform _transform;
        protected override void OnAttached()
        {
            if (TranformMode == TransformMode.Render)
            {
                _transform = AssociatedObject.RenderTransform = new MatrixTransform();
            }
            else
            {
                _transform = AssociatedObject.LayoutTransform = new MatrixTransform();
            }
            AssociatedObject.MouseWheel += AssociatedObject_MouseWheel;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.MouseWheel -= AssociatedObject_MouseWheel;
        }
        private void AssociatedObject_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if ((!ModifierKey.HasValue || !Keyboard.IsKeyDown(ModifierKey.Value)) && ModifierKey.HasValue)
            {
                return;
            }
            if (!(_transform is MatrixTransform transform))
            {
                return;
            }
            var pos1 = e.GetPosition(AssociatedObject);
            var scale = e.Delta > 0 ? 1.1 : 1 / 1.1;
            var mat = transform.Matrix;
            mat.ScaleAt(scale, scale, pos1.X, pos1.Y);
            transform.Matrix = mat;
            e.Handled = true;
        }
    }
    public enum TransformMode
    {
        Layout,
        Render,
    }
