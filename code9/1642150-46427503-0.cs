    public class ZoomOnMouseWheel : Behavior<UIElement>
    {
        protected override void OnAttached()
        {
            AssociatedObject.RenderTransform = new MatrixTransform();
            AssociatedObject.MouseWheel += AssociatedObject_MouseWheel;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.MouseWheel -= AssociatedObject_MouseWheel;
        }
        private void AssociatedObject_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var pos1 = e.GetPosition(AssociatedObject);
            var scale = e.Delta > 0 ? 1.1 : 1 / 1.1;
            var mat = matTrans.Matrix;
            mat.ScaleAt(scale, scale, pos1.X, pos1.Y);
            matTrans.Matrix = mat;
            e.Handled = true;
        }
    }
