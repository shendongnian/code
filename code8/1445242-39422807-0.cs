         public void bindEmpCustInvoice(string strCusCode)
        {
            try
            {
               
                Customer_Card[] cardList = cls.wsCustomerCard.ReadMultiple(null, null, 999999); Customer_Ledger_Entries[] billList = cls.wsCustInvoice.ReadMultiple(null,null,99999);
                var q = (from cd in cardList
                         join bd in billList on cd.No equals bd.Customer_No
                         orderby cd.No
                         select new
                             {
                                 cd.No,
                                 cd.Name,
                                 cd.Contact,
                                 cd.Phone_No,
                                 cd.City,
                                 bd.Amount });
                RptEmpCustInvoise.DataSource = q.ToList();
                RptEmpCustInvoise.DataBind();
            }
            catch { throw; }
        }
