    public class CardDealerUi : MonoBehaviour
    {
        [SerializeField] private GameObject cardPrefab;
    
        private Vector2 botCenterScreenSpace;
        private Vector3 botCenterWorldSpace;
    
        void Start()
        {
            this.botCenterScreenSpace = new Vector2(Screen.width/2, 0);
            this.botCenterWorldSpace = Camera.main.ScreenToWorldPoint(new Vector3(botCenterScreenSpace.x, botCenterScreenSpace.y, Camera.main.nearClipPlane));
        }
    
        void OnCardsDrawn(List<Card> cardsDrawn)
        {
             for(int i = 0; i < cardsDrawn.Length; i++)
            {
                var cardPosition = this.botCenterWorldSpace -totalWidth + (totalWidth/cardsDrawn.Length*i) + CardWidth/2;
                GameObject newCardUi = GameObject.Instantiate(this.cardPrefab, cardPosition , Quaternion.indentity);
            }
            
            // Here you can swap sprites for your cards or so.
        }
    }
