        private Tuple<Point3D> WriteTriangles(IXbimMeshGeometry3D wpfMeshGeometry3D)
        {
            var axesMeshBuilder = new MeshBuilder();
            var pos = wpfMeshGeometry3D.Positions.ToArray();
            var nor = wpfMeshGeometry3D.Normals.ToArray();
            var areasum = 0.00;
            for (var i = 0; i < wpfMeshGeometry3D.TriangleIndices.Count; i += 3)
            {
                var p1 = wpfMeshGeometry3D.TriangleIndices[i];
                var p2 = wpfMeshGeometry3D.TriangleIndices[i + 1];
                var p3 = wpfMeshGeometry3D.TriangleIndices[i + 2];
                if (nor[p1] == nor[p2] && nor[p1] == nor[p3]) // same normals
                {
                    var cnt = FindCentroid(new[] { pos[p1], pos[p2], pos[p3] });
                    CreateNormal(cnt, nor[p1], axesMeshBuilder);
                }
                else
                {
                    CreateNormal(pos[p1], nor[p1], axesMeshBuilder);
                    CreateNormal(pos[p2], nor[p2], axesMeshBuilder);
                    CreateNormal(pos[p3], nor[p3], axesMeshBuilder);
                }
                var point1 = new Point3D(pos[p1].X, pos[p1].Y, pos[p1].Z);
                var point2 = new Point3D(pos[p2].X, pos[p2].Y, pos[p2].Z);
                var point3 = new Point3D(pos[p3].X, pos[p3].Y, pos[p3].Z);
            }
            return Tuple.Create(point1, point2, point3);
        }
