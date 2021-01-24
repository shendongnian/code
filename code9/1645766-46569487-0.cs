    private static PlayerNodePosition playerNodePosition;
    public static PlayerNodePosition instance
    {
        get 
        {
            if (playerNodePosition == null) {
                playerNodePosition = new PlayerNodePosition();
            }
            return playerNodePosition;
        }
    }
