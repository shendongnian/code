    List<string> totalData = new List<string>();
    totalData.Add("Jan, 25");
    totalData.Add("Feb, 42");
    
    StringBuilder sb = new StringBuilder();
    sb.Append("<script>");
    sb.Append("var TotalData = new Array();");
    foreach(string str in tempData)
    {
      sb.Append("TotalData.push('" + str + "');");
    }
    sb.Append("</script>");
    ClientScript.RegisterStartupScript(this.GetType(), "InitTotalData", sb.ToString());
