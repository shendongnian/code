    public List<GameObject> Deck = new List<GameObject>(); // im assuming Deck is your list with prefabs?
    public List<GameObject> CreatedCards = new List<GameObject>();
    
    void Start()
    {
         Fill();
    }
    public void Fill()
    {
        foreach(GameObject _go in Deck)
        {
            GameObject _newCard = (GameObject)Instantiate(_go);
            CreatedCards.Add(_newCard);
        }
    }
