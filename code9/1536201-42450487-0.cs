    public class CellCommonData : MonoBehaviour // Datastore
    {
    	public bool IsShipCell { get; set; } // is a ship there?
    
        public bool WasActivated { get; set; } // cell already clicked
    
        [SerializeField]
        private Color defaultColor; // default Color -> light blue
    
        public Color DefaultColor { get { return defaultColor; } }
    
        [SerializeField]
        private Color mouseOverColor; // hover Color -> dark blue
    
    	public Color MouseOverColor { get { return mouseOverColor; } }
    
        [SerializeField]
        private Color hitColor; // hit Color -> green
    
    	public Color HitColor { get { return hitColor; } }
    
        [SerializeField]
        private Color noHitColor; // no Hit -> red
    
    	public Color NoHitColor { get { return noHitColor; } }
    
        private void Start()
        {
            WasActivated = false; // the cell is not clicked on Start
        }
    }
