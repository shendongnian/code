    if (msg == "true")
    {
        o.UpdateOrderStatus(orderid, "Received");
        gridOrders.DataSource = o.ManageOrders(UtilityClass.ReadFromCookie("login", "OutletD", Request));
        gridOrders.DataBind();
        UpdatePanelName.Update();
        Session["orderid"] = orderid;
        Server.Transfer("OrderPrint.aspx"); 
    }
