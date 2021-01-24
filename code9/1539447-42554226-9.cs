    public class ScoreManager
        : MonoBehaviour, ICoinPickedHandler
    {
        private int m_Score;
 
        public void OnCoinPickedUp(CoinPickedEventData eventData)
        {
            this.m_Score += eventData.Score;
            eventData.Use();
        }
        // code to display score or whatever ...
    }
