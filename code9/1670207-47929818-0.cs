    public abstract class Character
    {
        ...
        public bool isAlive();
    }
    ...
    bool allDead = true;
    foreach(Character char in spellteam)
    {
        if(Character.isAlive())
        {
            allDead = false;
            break;
        }
    }
    if(allDead)
    {
        //Do whatever you need to do when everyone is dead.
    }
    
