    public class Camera
    {
        public Vector3D Pos { get; private set; }
        public Vector3D Forward { get; private set; }
        public Vector3D Up { get; private set; }
        public Vector3D Right { get; private set; }
    
        public Camera(Vector3D pos, Vector3D lookAt)
        {
            Pos = pos;
            Forward = lookAt - pos;
            Forward.Normalize();
            Vector3D Down = new Vector3D(0, -1, 0);
            Right = Vector3D.CrossProduct(Forward, Down);
            Right.Normalize();
            Right *= 1.5;
            Up = Vector3D.CrossProduct(Forward, Right);
            Up.Normalize();
            Up *= 1.5;
        }
    }
