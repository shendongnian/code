    private static ulong berdyevID = 76561198040013516;
    private static ulong steamID;
    
    
    void Start() {
    
        if(SteamManager.Initialized) {
    
            string name = SteamFriends.GetPersonaName();
    
            // get steam user id
            steamID = Steamworks.SteamUser.GetSteamID().m_SteamID;
    
            // see if it matches
            if (berdyevID == steamID) {
    
                Debug.Log ("Steam ID did match");
            } else {
    
                Debug.Log ("Steam ID did not match");
            }
        }
    }
