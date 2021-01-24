        private static XbimPoint3D FindCentroid(XbimPoint3D[] p)
        {
            double x = 0;
            double y = 0;
            double z = 0;
            var n = 0;
            foreach (var item in p)
            {
                x += item.X;
                y += item.Y;
                z += item.Z;
                n++;
            }
            if (n <= 0)
                return new XbimPoint3D(x, y, z);
            x /= n;
            y /= n;
            z /= n;
            return new XbimPoint3D(x, y, z);
        }
        private static void CreateNormal(XbimPoint3D pnt, XbimVector3D vector3D, MeshBuilder axesMeshBuilder)
        {
            var cnt = new Point3D() { X = pnt.X, Y = pnt.Y, Z = pnt.Z };
            var path = new List<Point3D> { cnt };
            const double nrmRatio = .2;
            path.Add(
                new Point3D(
                    cnt.X + vector3D.X * nrmRatio,
                    cnt.Y + vector3D.Y * nrmRatio,
                    cnt.Z + vector3D.Z * nrmRatio
                    ));
            const double lineThickness = 0.001;
            axesMeshBuilder.AddTube(path, lineThickness, 9, false);
        }
        
        private static WpfMeshGeometry3D GetGeometry(IPersistEntity selection, XbimMatrix3D modelTransform, Material mat)
        {
            var tgt = new WpfMeshGeometry3D(mat, mat);
            tgt.BeginUpdate();
            using (var geomstore = selection.Model.GeometryStore)
            {
                using (var geomReader = geomstore.BeginRead())
                {
                    foreach (var shapeInstance in geomReader.ShapeInstancesOfEntity(selection).Where(x => x.RepresentationType == XbimGeometryRepresentationType.OpeningsAndAdditionsIncluded))
                    {
                        IXbimShapeGeometryData shapegeom = geomReader.ShapeGeometry(shapeInstance.ShapeGeometryLabel);
                        if (shapegeom.Format != (byte)XbimGeometryType.PolyhedronBinary)
                            continue;
                        var transform = shapeInstance.Transformation * modelTransform;
                        tgt.Add(
                            shapegeom.ShapeData,
                            shapeInstance.IfcTypeId,
                            shapeInstance.IfcProductLabel,
                            shapeInstance.InstanceLabel,
                            transform,
                            (short)selection.Model.UserDefinedId
                            );
                    }
                }
            }
            tgt.EndUpdate();
            return tgt;
        }
        private static DiffuseMaterial GetStyleFromXbimModel(IIfcProduct item, double opacity = 1)
        {
            var context = new Xbim3DModelContext(item.Model);
            var productShape = context.ShapeInstancesOf(item)
                .Where(s => s.RepresentationType != XbimGeometryRepresentationType.OpeningsAndAdditionsExcluded)
                .ToList();
            var wpfMaterial = GetWpfMaterial(item.Model, productShape.Count > 0 ? productShape[0].StyleLabel : 0);
            
            var newmaterial = wpfMaterial.Clone();
            ((DiffuseMaterial)newmaterial).Brush.Opacity = opacity;
            return newmaterial as DiffuseMaterial;
        }
        private static Material GetWpfMaterial(IModel model, int styleId)
        {
            var sStyle = model.Instances[styleId] as IIfcSurfaceStyle;
            var wpfMaterial = new WpfMaterial();
            if (sStyle != null)
            {
                var texture = XbimTexture.Create(sStyle);
                texture.DefinedObjectId = styleId;
                wpfMaterial.CreateMaterial(texture);
                return wpfMaterial;
            }
            var defautMaterial = ModelDataProvider.DefaultMaterials;
            Material material;
            if (defautMaterial.TryGetValue(model.GetType().Name, out material))
            {
                return material;
            }
            var color = new XbimColour("red", 1, 1, 1);
            wpfMaterial.CreateMaterial(color);
            return wpfMaterial;
        }
