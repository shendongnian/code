    string sessionVar;
    if (...)
    {
        sessionVar = table.Rows[0]["personID"].ToString();
    }
    else
    {
        sessionVar = null;
    }
    // using sessionVar is allowed now.
