    public class CameraMovement : MonoBehaviour {
        public GameObject LookTarget;
        public GameObject MainCamera;
        public GameObject NextMovePoint;
        public Path[] Paths;
        private int _currentPoint = 0;
    }
    [System.Serializable]
    public class Path {
        public float Time;
        public Transform[] MovePoints;
    }
