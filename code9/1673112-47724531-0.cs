    public void Something(in Point3D point1)
    {
        SomethingElse(ref point1); // not allowed
    }
    public void SomethingElse(ref Point3D pointAnother)
    {}
