    public static Model3DCollection GetModel3DCollectionByTemplates(List<GeometryTemplate> geometryTemplates) {
            var modelCollection = new Model3DCollection();
            foreach (var geometryTemplate in geometryTemplates) {
                var positions = geometryTemplate.Positions;
                var indicies = geometryTemplate.Indicies;
                var normals = geometryTemplate.Normals;
                var meshGeometry3D = new MeshGeometry3D {
                    Positions = new Point3DCollection(positions),
                    TriangleIndices = new Int32Collection(indicies),
                    Normals = new Vector3DCollection(normals)
                };
                var geometry = new GeometryModel3D(meshGeometry3D,
                    new DiffuseMaterial(new SolidColorBrush(Colors.Aquamarine)));
                modelCollection.Add(geometry);
            }
            // =======================
            return modelCollection;
        }
