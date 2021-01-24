    void ProcessList(List<MonoBehaviour> list)
    {
        foreach(var l in list)
        {
            if(l is Enemy)
            {
                var enemy = (Enemy) l;
                //process the enemy
            }
            else
            {
                var player = (Player) l;
                //process as a player
            }
        }
    }
