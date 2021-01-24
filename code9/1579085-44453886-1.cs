      try
            {
                ServicesSoapClient client = new ServicesSoapClient("ServicesSoap");
                Task<CustomerAccountInfo[]> GetAccount = client.GetAccountAsync(User, Password, DemoAccount);
                CustomerAccountInfo[] AccountInfor = await GetAccount;
                foreach(CustomerAccountInfo a in AccountInfor)
                {
                    AccountView.Add(a);
                }
            }
            catch (Exception ex)
            {
                AccountView.Error = ex.ToString();
                return BadRequest(ex.ToString());
            }
