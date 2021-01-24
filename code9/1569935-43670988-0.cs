    for (int i = 0; i < thisSpot.ownMenus.Count; i++)
        {
            if (thisSpot.ownMenus[i].uiSort == SpotUISort.StatEvent)
            {
                thisSpot.ownMenus[i] = SpotUI.Instance.StatEvent;
                var ownMenu = (StatEvent) thisSpot.ownMenus[i];
                Debug.Log("own menu is "+ownMenu.Name);
                if ((!ownMenu.StatChal1.nowCoolTime && ownMenu.StatChal1 != null)
                                                 || ownMenu.StatChal1 == null)
                {
                    StatChallenge.Instance.MakeStatChal(this, ref ownMenu.StatChal1);
                    Debug.Log(ownMenu.StatChal1.Name);
                    ownMenu.SetChalInfo(ownMenu.StatChal1, 1);
                    chal1 = ownMenu.StatChal1;
                }
