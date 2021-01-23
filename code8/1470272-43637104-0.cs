    public static void Enable(DirectoryEntry user)
        {
            try
            {
                int val = (int)user.Properties["userAccountControl"].Value;
                user.Properties["userAccountControl"].Value = val & ~0x2;
                //ADS_UF_NORMAL_ACCOUNT;
                user.CommitChanges();
                user.Close();
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                //DoSomethingWith --> E.Message.ToString();
            }
        }
