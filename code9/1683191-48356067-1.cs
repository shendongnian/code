    IntVariable upg_Hull_cost;
    IntVariable upg_Hull_impactRes;
    //.....
    
    IntVariable GetVariable(UpgradeType type) {
        switch(type) {
            case UpgradeType.COST:
                return upg_Hull_cost;
            case UpgradeType.IMPACT_RES:
                return upg_Hull_impactRes;
                //....
        }
        return null;
    }
    ///...
    void GetHullUpgradeVals(GDEHullData hullDat){
         GetVariable(hullDat.upgd_1_type).Value = hullDat.upgd_1_amnt;
         GetVariable(hullDat.upgd_2_type).Value = hullDat.upgd_2_amnt;
         //...
         GetVariable(UPGRADES_HULL.COST).DivideAndMultiply();
    }
