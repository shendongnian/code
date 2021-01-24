    int tidValue;
    int tcvvValue;
    if (!int.TryParse(tid, out tidValue))
    {
        Response.Write("<script>alert('The value specified for TID is not an integer.');</script>");
    }
    else if (!int.TryParse(tcvv, out tcvvValue))
    {
        Response.Write("<script>alert('The value specified for TCVV is not an integer.');</script>");
    }
    else
    {
        result = prod.CardUpdate(tidValue, tholdername, tnumber, texpirydate, tcvvValue, tcardtype);
        if (result > 0)
        {
            Response.Write("<script>alert('Product updated successfully');</script>");
        }
        else
        {
            Response.Write("<script>alert('Product NOT updated');</script>");
        }
    }
