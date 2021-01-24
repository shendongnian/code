    class GameFlowManager
    {
        public static GameFlowManager Instance {get; private set;}
        public float worldSpeed{get; set;} // You could make the setter private to prevent other classes from modifying it if necessary
        void Awake()
        {
            Instance = this; // Note that this requires an object of type GameFlowManager to already exist in your scene. You could also handle the spawning of this object automatically to remove this requirement.
        }
        ...
    }
