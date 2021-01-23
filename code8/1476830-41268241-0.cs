    Point3D point3D;
    var hitList = yourHelixViewPort.ViewPort.FindHits(Point point);
    foreach (var hit in hitList)
    {
        if (hit.Visual != null) 
        {
            if (hit.Visual.GetName() == "ModelName")
            {
                point3D = hit.Position;
                // You can use also hit.Mesh
                // also hit.Model
                // also hit.Visual
                // also hit.Normal
            }
        }
    }
