    class MeshAnimation : MonoBehaviour
    {
        public Mesh[] frames = new Mesh[0];
        public float animationSpeed = .1f;
        private float animationStartTime;
        private int currentFrame;
        void Start()
        {
            currentFrame = 0;
            animationStartTime = Time.time;
            UpdateMesh();
        }
        void Update()
        {
            currentFrame = Mathf.FloorToInt((Time.time - animationStartTime) / animationSpeed);
            currentFrame = currentFrame % frames.Length;
            UpdateMesh();
        }
        void UpdateMesh()
        {
            GetComponent<MeshFilter>().mesh = frames[currentFrame];
        }
    }
