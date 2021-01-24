    void OnEnable()
    {
        player_bullet_mover.OnDamaged += damagedCallBack;
    }
    
    
    void OnDisable()
    {
        player_bullet_mover.OnDamaged -= damagedCallBack;
    }
    
    void damagedCallBack()
    {
        UnityEngine.Debug.Log("Damaged!");
    }
     
