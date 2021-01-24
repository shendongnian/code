    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.NumPad6)
        {
            Rotate(10);
        }
        else if (e.Key == Key.NumPad4)
        {
            Rotate(-10);
        }
        else if (e.Key == Key.NumPad8)
        {
            Move(-10);
        }
        else if (e.Key == Key.NumPad2)
        {
            Move(10);
        }
        else if (e.Key == Key.PageUp)
        {
            RotateVertical(10);
        }
        else if (e.Key == Key.PageDown)
        {
            RotateVertical(-10);
        }
    }
    public void Rotate(double d)
    {
        double u = 0.05;
        double angleD = u * d;
        PerspectiveCamera camera = (PerspectiveCamera)Viewport3D.Camera;
        Vector3D lookDirection = camera.LookDirection;
        var m = new Matrix3D();
        m.Rotate(new Quaternion(camera.UpDirection, -angleD)); // Rotate about the camera's up direction to look left/right
        camera.LookDirection = m.Transform(camera.LookDirection);
    }
    public void RotateVertical(double d)
    {
        double u = 0.05;
        double angleD = u * d;
        PerspectiveCamera camera = (PerspectiveCamera)Viewport3D.Camera;
        Vector3D lookDirection = camera.LookDirection;
        // Cross Product gets a vector that is perpendicular to the passed in vectors (order does matter, reverse the order and the vector will point in the reverse direction)
        var cp = Vector3D.CrossProduct(camera.UpDirection, lookDirection);
        cp.Normalize();
        var m = new Matrix3D();
        m.Rotate(new Quaternion(cp, -angleD)); // Rotate about the vector from the cross product
        camera.LookDirection = m.Transform(camera.LookDirection);
    }
