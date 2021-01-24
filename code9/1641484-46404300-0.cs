    ds.Tables[0].Columns.Add("Codes");
    foreach (DataRow row in ds.Tables[0].Rows)
    {
        row["Codes"] = string.Join(",", ds.Tables[1]
                        .Select($"SubscriberEligibilityOrBenefitInformation_ID = {row["SubscriberEligibilityOrBenefitInformation_ID"]}")
                        .Select(r=>r["ServiceTypeCode_Text"]));
    }
