    /// <summary>Add this to a player prefab.</summary>
    public class PlayerSettings : MonoBehaviour{
        /// <summary>Still following the singleton pattern.</summary>
        public static PlayerSettings Current;
       
        /// <summary>Player speed. This can be edited in the inspector.</summary>
        public float Speed;
    
        public void Awake() {
            // Update the static field:
            Current = this;
        }
    
    }
