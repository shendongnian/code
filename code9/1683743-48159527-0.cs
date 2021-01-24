    if (e.Row.RowType == DataControlRowType.DataRow)
          {
          string requestId = gvCustomers.DataKeys[e.Row.RowIndex].Value.ToString();
          GridView gvOrders = e.Row.FindControl("gvOrders") as GridView;
          gvOrders.DataSource = GetData(string.Format("select top 10 * from Orders where RequestID='{0}'", requestId));
          gvOrders.DataBind(); // this is the childGV
          System.Data.DataRowView dr = (System.Data.DataRowView)e.Row.DataItem;
          string requestStatus = dr["myColumnHeader"].ToString();
      }
      }
