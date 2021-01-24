    public class DropDownToToggle : MonoBehaviour 
    {
        public Toggle[] toggles;
    
        public void OnDropDownValueChanged(int index)
        {
            if ( toggles.Length == 0 || index > toggles.Length)
            {
                return; // Toggles are not assigned from inspector.
            }
    
            for (int i = 0; i < toggles.Length; i++)
            {
                toggles[i].isOn = (i == index);
            }
        }
    }
