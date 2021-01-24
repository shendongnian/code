        private string[] retFlds = { "Id", "ContactId", "OriginatingOrderId", "ProgramId", "SubscriptionPlanId", "ProductId", "StartDate", "NextBillDate", "BillingCycle", "Frequency", "BillingAmt", "Status", "ReasonStopped", "AutoCharge", "CC1", "CC2", "NumDaysBetweenRetry", "MaxRetry", "MerchantAccountId", "AffiliateId", "PromoCode", "LeadAffiliateId", "Qty", "ShippingOptionId" };
        private string table = "RecurringOrder";
        private DataTable dt = new DataTable();
        // here's the query 
        XmlRpcStruct[] retData = proxy.Query(Auth.key, table, 1000, 0, qryData, returnFields);
        dt = StructArrayToDT(retData);
        
        public static DataTable StructArrayToDT(XmlRpcStruct[] data)
        {
            DataTable dt = new DataTable();
            if (data.Length == 0) { return dt; }
            
            // do columns
            foreach (DictionaryEntry d in data[0])
            {
                dt.Columns.Add(d.Key.ToString(), typeof(object));
            }
            foreach (XmlRpcStruct xmlstruct in data)
            {
                DataRow dr = dt.NewRow();
                foreach (DictionaryEntry d in xmlstruct)
                {
                    try
                    {
                        dr[d.Key.ToString()] = d.Value;
                    }
                    catch (Exception ex)
                    { 
                        // handle errors
                    }
                        
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        
     
