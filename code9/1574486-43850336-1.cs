    public PXAction<POReceipt> report;
        [PXUIField(DisplayName = "Reports", MapEnableRights = PXCacheRights.Select)]
        [PXButton]
        protected virtual IEnumerable Report(PXAdapter adapter,			
		
		[PXString(8, InputMask = "CC.CC.CC.CC")]
		[PXStringList(new string[] { "PO646000", "PO632000", "PO622000" }, new string[] { "Purchase Receipt", Messages.ReportPOReceiptBillingDetails, Messages.ReportPOReceipAllocated })]
		string reportID)
        {
            List<POReceipt> list = adapter.Get<POReceipt>().ToList();
		if (string.IsNullOrEmpty(reportID) == false)
		{
                Save.Press();
			int i = 0;
			Dictionary<string, string> parameters = new Dictionary<string, string>();
                foreach (POReceipt doc in list)
			{
				if (reportID == "PO632000")
				{
					parameters["FinPeriodID"] = (string)Document.GetValueExt<POReceipt.finPeriodID>(doc);
                        parameters["ReceiptNbr"] = doc.ReceiptNbr;
				}
				else
				{
                        parameters["ReceiptType"] = doc.ReceiptType;
					parameters["ReceiptNbr"] = doc.ReceiptNbr;
				}
				i++;
			}
			if (i > 0)
			{
				throw new PXReportRequiredException(parameters, reportID, string.Format("Report {0}", reportID));
			}
		}
            return list;
        }
