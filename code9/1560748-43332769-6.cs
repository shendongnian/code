        Regex reFromUser = new Regex(txtFromUser.Text);
        string[] asGroupNames = reParts.GetGroupNames();
        int iItsInt;
        foreach (string sGroupName in asGroupNames)
        {
            if (!Int32.TryParse(sGroupName, out iItsInt)) //don't want numbered groups
            {
                string sSubExpression = reParts.GetSubExpression(sGroupName);
                //Do what I need to do with the sub-expression
            }
        }
