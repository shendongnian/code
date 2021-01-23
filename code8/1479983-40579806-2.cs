        // you check if the item["ID"] is null?
        string ticketid = item["ID"].Text;
        // are you making sure you are not overiding this session variable some place on the page
        Session["viewID"] = ticketid;
    // this should get the id on the query string if you don't want to use session.
    Response.Redirect(String.Builder("View.aspx?ViewID={0}", ticketid));
