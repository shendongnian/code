    public class PlaneBehaviour : MonoBehaviour {
        public GameObject ClickSymbol;
        private static bool _keyDownHandled { get; set; }
        public void Update() {
            if (Input.GetMouseButtonDown(0)) {
                if (_keyDownHandled)
                    Instantiate(ClickSymbol, Input.mousePosition, Quaternion.identity);
                _keyDownHandled = true;
            }
            if (Input.GetMouseButtonUp(0)) {
                _keyDownHandled = false;
            }
        }
    }
