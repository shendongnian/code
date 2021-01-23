    public Player player;
    void Start(){
        if(player == null)
           player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player> ();
    }
