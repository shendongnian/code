    public class Test : MonoBehaviour
    {
        private DateTime m_LastOpening;
        public Button m_BoxButton;
    
        public void BoxClicked()
        {
            DateTime now = DateTime.Now;
    
            // 5 minutes elapsed, you can open the box
            if ((now - m_LastOpening).TotalMinutes > 5)
            {
                m_LastOpening = now;
                m_BoxButton.interactable = false;
            }
            else // otherwise you have to wait
            {
                // ...
            }
        }
    }
