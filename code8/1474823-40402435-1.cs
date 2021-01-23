    public class InvoiceContext : DbContext
    {
        // DbSet properties left out
        #region stored procedures
        private const string StoredProcedureNameProcessUsageCosts = "processusagecosts";
        public void CallStoredProcedureProcessUsageCosts(UsageCosts usageCosts)
        {
            object[] functionParameters = new object[]
            {
                new SqlParameter(@"ReportDate", usageCosts.ReportPeriod),
                new SqlParameter(@"CustomerContractId", usageCosts.CustomerContractId),
                new SqlParameter(@"CallType", usageCosts.CallType),
                new SqlParameter(@"TariffGroup", usageCosts.TariffGroup),
                new SqlParameter(@"VatValue", usageCosts.VatValue),
                new SqlParameter(@"PurchaseCosts", usageCosts.PurchaseCosts),
                new SqlParameter(@"RetailCosts", usageCosts.RetailCosts),
            };
            const string sqlCommand = @"Exec " + StoredProcedureNameProcessUsageCosts
                + " @ReportDate, @CustomerContractId, @CallType, @TariffGroup, @VatValue,"
                + " @PurchaseCosts, @RetailCosts";
            this.Database.ExecuteSqlCommand(sqlCommand, functionParameters);
        }
		public bool StoredProcedureProcessUsageCostsExists()
		{
			return this.Exists(StoredProcedureNameProcessUsageCosts);
		}
        public void CreateProcedureProcessUsageCosts(bool forceRecreate)
        {
            bool storedProcedureExists = this.Exists (StoredProcedureNameUpdateUsageCosts);
            // only create (or update) if not exists or if forceRecreate:
            if (!storedProcedureExists || forceRecreate)
            {   // create or alter:
                var x = new StringBuilder();
                // ALTER or CREATE?
                if (!storedProcedureExists)
                {
                    x.Append(@"CREATE");
                }
                else
                {
                    x.Append(@"ALTER");
                }
                // procedure name:
                x.Append(@" procedure ");
                x.AppendLine(StoredProcedureNameProcessUsageCosts);
                // parameters:
                x.AppendLine(@"@ReportPeriod int,");
                x.AppendLine(@"@CustomerContractId bigint,");
                x.AppendLine(@"@CallType nvarChar(80),");
                x.AppendLine(@"@TariffGroup nvarChar(80),");
                x.AppendLine(@"@VatValue decimal(18, 2),");
                x.AppendLine(@"@PurchaseCosts decimal(18, 2),");
                x.AppendLine(@"@RetailCosts decimal(18, 2)");
                // code
                x.AppendLine(@"as");
                x.AppendLine(@"begin");
                x.AppendLine(@"Merge [usagecosts]");
                x.AppendLine(@"Using (Select @ReportPeriod as reportperiod,");
                x.AppendLine(@"              @CustomerContractId as customercontractId,");
                x.AppendLine(@"              @CallType as calltype,");
                x.AppendLine(@"			     @TariffGroup as tariffgroup,");
                x.AppendLine(@"              @VatValue as vatvalue)");
                x.AppendLine(@"              As tmp ");
                x.AppendLine(@"On ([usagecosts].[reportperiod] = tmp.reportperiod");
                x.AppendLine(@"AND [usagecosts].[customercontractId] = tmp.customercontractid");
                x.AppendLine(@"AND [usagecosts].[calltype] = tmp.calltype");
                x.AppendLine(@"AND [usagecosts].[tariffgroup] = tmp.tariffgroup");
                x.AppendLine(@"AND [usagecosts].[vatvalue] = tmp.Vatvalue)");
                x.AppendLine(@"When Matched Then ");
                x.AppendLine(@"    Update Set [usagecosts].[purchasecosts] = [usagecosts].[purchasecosts] + @purchasecosts,");
                x.AppendLine(@"               [usagecosts].[retailcosts] = [usagecosts].[retailcosts] + @retailcosts");
                x.AppendLine(@"When Not Matched Then");
                x.AppendLine(@"    Insert (ReportPeriod, CustomerContractId, calltype, tariffgroup, vatvalue, purchasecosts, retailcosts)");
                x.AppendLine(@"	   Values (@reportPeriod, @CustomerContractId, @CallType, @TariffGroup, @VatValue, @PurchaseCosts, @RetailCosts);");
                x.AppendLine(@"end");
                this.Database.ExecuteSqlCommand(x.ToString());
            }
            // else: procedure exists and no forced recreate, nothing to do
        }
        #endregion stored procedures
    }
