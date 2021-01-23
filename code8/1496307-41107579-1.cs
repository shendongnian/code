    public void savefile()
    {
        using (StreamWriter writer = new StreamWriter("customer.txt"))
        {
            for (int i = 0; i < cuslist.Count; i++)
            {
                var info = new List<string>
                {
                    cuslist[i].accounttype.ToString(),
                    cuslist[i].PIN,
                    cuslist[i].accountnumber,
                    cuslist[i].accountbalance.ToString()
                };
                var customer = String.Join(";", info);
                writer.WriteLine(customer);
            }
        }
    }
    
    public void saveaccount()
    {
        using (StreamWriter writer = new StreamWriter("account.txt"))
        {
            for (int i = 0; i < acclist.Count; i++)
            {
                var info = new List<string>
                {
                    acclist[i].accounttype.ToString(),
                    acclist[i].PIN,
                    acclist[i].accountnumber,
                    acclist[i].accountbalance.ToString()
                };
                var account = String.Join(";", info);
                writer.WriteLine(account);
            }
        }
    }
