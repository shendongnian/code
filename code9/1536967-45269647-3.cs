    public class GeometryTemplate {
        public List<Point3D> Positions { get; private set; }
        public List<Int32> Indicies { get; private set; }
        public List<Vector3D> Normals { get; private set; }
        public GeometryTemplate(MeshGeometry3D meshGeometry3D) {
            SetPositions(meshGeometry3D.Positions);
            SetIndicies(meshGeometry3D.TriangleIndices);
            SetNormals(meshGeometry3D.Normals);
        }
        private void SetNormals(Vector3DCollection normals) {
            Normals = new List<Vector3D>(normals);
        }
        private void SetIndicies(Int32Collection triangleIndices) {
            Indicies = new List<Int32>(triangleIndices);
        }
        private void SetPositions(Point3DCollection positions) {
            Positions = new List<Point3D>(positions);
        }
    }
