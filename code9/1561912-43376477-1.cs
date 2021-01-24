    public void Move(double d)
    {
        double u = 0.05;
        PerspectiveCamera camera = (PerspectiveCamera)Viewport3D.Camera;
        Vector3D lookDirection = camera.LookDirection;
        Point3D position = camera.Position;
        lookDirection.Normalize();
        position = position + u * lookDirection * d;
        camera.Position = position;
    }
