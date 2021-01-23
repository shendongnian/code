    public class PlayerBase : MonoBehaviour
    {
        static Color[] _allColors = { Color.blue, Color.red };
        public void SetColor(int index)
        {
             Color = _allColors[index];
        }        
    }
