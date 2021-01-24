        //gets unit A
        _masterUnit = Core.Model.Unit.GetById(Convert.ToInt32(ddlAllUnits.SelectedValue));
        //gets prices for A
        IList<Price> _masterPrices = Price.GetPricesOfUnit(_masterUnit.UnitId);
        //gets all Units 
        IList<Unit> allUnits = Core.Model.Unit.GetUnits();
        foreach(Unit unit in allUnits){
            //gets units price
            var unitPrices = Price.GetPricesOfUnit(_masterUnit.UnitId);
            for(int i = 0; i < unitPrices.length(); i++){
                //replaces start, end date with that of master unit    
                unitPrices[i].StartDate = _masterPrices[i].StartDate;                         
                unitPrices[i].EndDate= _masterPrices[i].EndDate;
                unitPrices[i].Save();
            }
        }
