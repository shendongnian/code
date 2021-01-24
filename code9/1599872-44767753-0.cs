    if (sd.IsNew)
        sd.Save(); //must save to get default GL Accounts, then they can be overwritten
    if (sd.LineItems.Count(s => s.val_Is_Non_Inventory && !s.IsMarkedToDelete && !s.IsDeleted) > 0)
    {
        SystemUser sysUser = new SystemUser(Framework.Controller.Credentials.UserName);
        foreach (SalesLineItem sli in sd.LineItems.Where(s => s.val_Is_Non_Inventory && !s.IsMarkedToDelete && !s.IsDeleted))
            sli.val_Sales_Account = Genframe4.Utils.ConvertToString(sysUser["xGL_Sales_Acct"]);
    }
    if (sd.val_Sales_Doc_Type == "INVOICE" && sd.val_Misc_Charge != (decimal) sd.Customer["xHandlingFeeAmount"])
        sd["xOverrideFee"] = true;
    else
        sd["xOverrideFee"] = false;
    return String.Empty;
