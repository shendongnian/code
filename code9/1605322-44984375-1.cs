    #define EDIT_MODE // if you delete this, code in EDIT_MODE fields will ignored and never compiled
    public class Line : MonoBehaviour {
        public LineManagerProperty lineManagerProperty;
        LineManager lineManager;
        void Start() {
    #if EDIT_MODE
            lineManager = new LineManager(lineManagerProperty);
    #endif
        }
        void Update() {
    #if EDIT_MODE
            lineManager.Update();// if you want to call somethink
    #endif
        }
    }
    public class LineManager  {
       public LineManager(LineManagerProperty lmp) {
           LineManagerProperty = lmp;
       }
       public LineManagerProperty LineManagerProperty;
    
       public void Update() { // if you want to call somethink
       }
    }
