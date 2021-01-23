    ObjReader Reader = new HelixToolkit.Wpf.SharpDX.ObjReader();
    List<Object3D> objs = Reader.Read(ModelPath);
    var ele3DCollection = new Element3DCollection();
    foreach (var ob in objs)
    {
        var meshGeometry = new MeshGeometryModel3D
        {
            Geometry = ob.Geometry,
            Material = ob.Material,
        };
        ele3DCollection.Add(meshGeometry);
        // Run this line if you are using a render host
        meshGeometry.Attach(Viewport3D.RenderHost);
    }
    
    // Now assign the ele3DCollection to the property you bound to and raise property changed
    YourElement3DCollection = ele3DCollection;
