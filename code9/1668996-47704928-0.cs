    IGeometryBag pGeomBag = new GeometryBagClass();
    pGeomBag.SpatialReference = .......
    
    IGeometryCollection pGeomColl = new PolylineClass();
    pGeomColl = (IGeometryCollection)pGeomBag;
    IEnumGeometry pEnum = new EnumFeatureGeometryClass();
    pEnum = (IEnumGeometry)pGeomBag;
