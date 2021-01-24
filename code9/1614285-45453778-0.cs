    public void ApplyCreditsOnPrePayInvoices(string sMonth, string sYear)
    {
      IMsgSetRequest IMsgSetRequestToQB = null;
      ICreditMemoQuery ICreditMemoQueryToQB = null;
      string sInvoiceTxnId = string.Empty;
      string sInvoiceNumber = string.Empty;
      if (this.GetConnectedToQB())
      {
        try
        {
          IMsgSetRequestToQB = m_sessionManager.CreateMsgSetRequest("US", 8, 0);
          ICreditMemoQueryToQB = IMsgSetRequestToQB.AppendCreditMemoQueryRq();
          ICreditMemoQueryToQB.ORTxnQuery.TxnFilter.ORDateRangeFilter.ModifiedDateRangeFilter.FromModifiedDate.SetValue(DateTimecl.GetValue("1." + sMonth + sYear), true);
          IMsgSetResponse IMsgSetResponseFromQB = m_sessionManager.DoRequests(IMsgSetRequestToQB);
          IResponseList ICreditListMemoAvailable = IMsgSetResponseFromQB.ResponseList;
          if (ICreditListMemoAvailable.Count > 0)
          {
            string sCustomerListIdQB = string.Empty;
            string sCustomerAccountNumber = string.Empty;
            string sQBImportPrepayAccounts = Path.Combine(Environment.CurrentDirectory, sMonth + sYear, "Step11_QBImport_PrepayAccounts.csv");
            DataTable dtQBImportPrepayAccounts = Utilcl.GetDataTableFromCSVFile(sQBImportPrepayAccounts);
            IResponse ICreditMemoAvailable = ICreditListMemoAvailable.GetAt(0);
            ICreditMemoRetList iCreditMemoList = ICreditMemoAvailable.Detail as ICreditMemoRetList;
            if (iCreditMemoList != null)
            {
              for (int iCtr = 0; iCtr <= iCreditMemoList.Count - 1; iCtr++)
              {
                ICreditMemoRet ICreditMemo = iCreditMemoList.GetAt(iCtr);
                DataRow[] drInvoiceNos = dtQBImportPrepayAccounts.Select("RefNumber = '" + ICreditMemo.RefNumber.GetValue() + "'");
                if (drInvoiceNos.Length > 0)
                {
                  sInvoiceNumber = Stringcl.GetValue(drInvoiceNos[0]["RefNumber"]);
                  m_requestMsgSet.ClearRequests();
                  m_requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;
                  IReceivePaymentAdd IReceivePayment = m_requestMsgSet.AppendReceivePaymentAddRq();
                  sInvoiceTxnId = this.GetQBInvoiceTxnIDList(ICreditMemo.CustomerRef.FullName.GetValue()); //To get the Transaction ID of Invoice
                  IReceivePayment.CustomerRef.FullName.SetValue(Stringcl.GetValue(ICreditMemo.CustomerRef.FullName.GetValue()));
                  IAppliedToTxnAdd IAppliedToTxnAddress = IReceivePayment.ORApplyPayment.AppliedToTxnAddList.Append();
                  IAppliedToTxnAddress.TxnID.SetValue(sInvoiceTxnId);
                  ISetCredit ISetCreditToInvoice = IAppliedToTxnAddress.SetCreditList.Append();
                  ISetCreditToInvoice.CreditTxnID.SetValue(ICreditMemo.TxnID.GetValue());
                  ISetCreditToInvoice.AppliedAmount.SetValue(ICreditMemo.TotalAmount.GetValue());
                  IMsgSetResponse responseApplyCredit = m_sessionManager.DoRequests(m_requestMsgSet);
                  DataSet dsInvoice = this.GetExtractResponseFromQB(responseApplyCredit);
                  string sQueryResponse = Stringcl.GetValue(dsInvoice.Tables["ReceivePaymentAddRs"].Rows[0]["statusMessage"]);
                  if (sQueryResponse != "Status OK")
                  {
                    Utilcl.LogMessage("QB Credit Memo Query Response: " + sQueryResponse);
                  }
                }
              }
            }
          }
        }
        catch (Exception ex)
        {
          Utilcl.LogMessage(ex);
        }
        finally
        {
          if (IMsgSetRequestToQB != null)
          {
            Marshal.FinalReleaseComObject(IMsgSetRequestToQB);
          }
          if (ICreditMemoQueryToQB != null)
          {
            Marshal.FinalReleaseComObject(ICreditMemoQueryToQB);
          }
        }
      }
    }
