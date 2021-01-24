    private void MainWindow_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var bounds = CalculateBounds(MyVisual);
        MyRegion.Width = bounds.Width;
        MyRegion.Height = bounds.Height;
        MyRegion.Margin = new Thickness(bounds.Left, bounds.Top, 0, 0);
    }
    public static Viewport3DVisual GetViewport3DVisual(Visual3D visual3D)
    {
        DependencyObject obj = visual3D;
        while (obj != null)
        {
            var visual = obj as Viewport3DVisual;
            if (visual != null)
            {
                return visual;
            }
            obj = VisualTreeHelper.GetParent(obj);
        }
        return null;
    }
    public static Rect CalculateBounds(Visual3D visual)
    {
        var transform = visual.TransformToAncestor(GetViewport3DVisual(visual));
        if (transform == null)
        {
            return Rect.Empty;
        }
        var bounds = Rect.Empty;
        var modelVisual3D = visual as ModelVisual3D;
        if (modelVisual3D != null)
        {
            bounds.Union(CalculateBounds(transform, modelVisual3D.Content, Matrix3D.Identity));
            // Unio the bounds of Children
            foreach (var child in modelVisual3D.Children)
            {
                bounds.Union(CalculateBounds(child));
            }
        }
        else
        {
            // UIElement3D or Viewport2DVisual3D 
            bounds.Union(transform.TransformBounds(VisualTreeHelper.GetDescendantBounds(visual)));
        }
        return bounds;
    }
    public static Rect CalculateBounds(GeneralTransform3DTo2D transform, Model3D model, Matrix3D rootMatrix)
    {
        var region = Rect.Empty;
        var matrix = Matrix3D.Identity;
        matrix.Prepend(rootMatrix);
        if (model.Transform != null)
        {
            matrix.Prepend(model.Transform.Value);
        }
        var geometryModel3D = model as GeometryModel3D;
        if (geometryModel3D != null)
        {
            var meshGeometry3D = geometryModel3D.Geometry as MeshGeometry3D;
            if (meshGeometry3D != null)
            {
                var innerTransform = new MatrixTransform3D(matrix);
                foreach (var position in meshGeometry3D.Positions)
                {
                    region.Union(transform.Transform(innerTransform.Transform(position)));
                }
            }
        }
        else
        {
            var model3DGroup = model as Model3DGroup;
            if (model3DGroup != null)
            {
                foreach (var child in model3DGroup.Children)
                {
                    region.Union(CalculateBounds(transform, child, matrix));
                }
            }
        }
        return region;
    } 
