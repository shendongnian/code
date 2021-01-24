    var wepGun = weapon as StatManager.WepGun;
    if(null != wepGun)
        wepGun.barrel = new StatManager.Part(StatManager.PartType.GUN_BARREL, StatManager.AttackType.CARDINAL_SINGLE_TARGET, 3, 0, 0.2f); 
    else
    {
       // debug code
    }
