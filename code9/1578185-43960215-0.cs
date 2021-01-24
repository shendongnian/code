    // Buildings
    [Header("Buildings")]
    public Button [] buildingTiers;
    public int numOfBuildingTiers = 6; // Number of building tier buttons;
    // ==============================================================
    void Awake()
    {
        buildingTiers = new Button[numOfBuildingTiers];
    
        for (var i = 1; i <= numOfBuildingTiers; i++)
        {
            Button _buildingTiers = GameObject.Find ("Tier " +    i).GetComponent<Button> (); // This is line 37
            buildingTiers [i] = _buildingTiers; // This is line 38
            buildingTiers [i].interactable = false;
        }    
    }
