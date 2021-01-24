    public void HpUpgrade()
    {
        stats.maxVal = (int)(stats.Instance.maxVal += hpUp);
    }
    public void DmgUpgrade()
    {
        dmg.playerDamage = (int)(stats.Instance.maxVal += dmgUp);
    }
