    string message = "Account is invalid.";
    for (int i = 0; i < acct.Length; i++)
    {
        if (txtAccount.Text.Contains(acct[i]))
        {
            message = "Account is valid";
            break;
        }
    }
    lblMessage.Text = message;
