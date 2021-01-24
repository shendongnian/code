    int customerCompanyID = Convert.ToInt32(dr["IRPCustomerID"]);
     if (customerCompanyID != this._trafficSourceGridCurrentCompanyID)
                {
                    if (this._trafficSourceGridGroupingCssClass == 
    "BackGround2")
                    {
                        this._trafficSourceGridGroupingCssClass = "BackGround1";
                    }
                    else
                    {
                        this._trafficSourceGridGroupingCssClass = "BackGround2";
                    }
                    this._trafficSourceGridCurrentCompanyID = customerCompanyID;                    
                }
                e.Row.CssClass = _trafficSourceGridGroupingCssClass;
