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
    
        void OnCardDrawn(Card cardDrawn)
        {
            GameObject newCardUi = GameObject.Instantiate(this.cardPrefab, this.botCenterWorldSpace, Quaternion.indentity);
            // Here you can swap sprites for your cards or so.
        }
    }
