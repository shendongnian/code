    public abstract class WidgetListGear<T> : MonoBehaviour
        where T : IGear
    {
    
        public void ActionSelected(T gear) {
            if (...) GameSession.Equip(gear);
        }
    }
