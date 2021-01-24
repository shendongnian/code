    for (int i = 0; i < accountCount; i++)
    {
        //// account is found in the array                
        name[i] = account.Entities[i].Attributes["name"].ToString();
        if (name[i].Contains(message.Current.org_name)
            || message.Current.org_name.Contains(name[i]))
        {
            flag = 1;
            break;
        }
    }                
     //// account is not found in the array                 
    if (flag == 0)
        c.CreateAccount(message);
    c.CreateOpportunity(message);
