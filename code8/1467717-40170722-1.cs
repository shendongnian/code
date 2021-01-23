    <form id="form1" runat="server">
        <div>
            <ul>
                <%
                    // Here I have created dummy data-object(DataTable), but You can fetch data from Database.
                    System.Data.DataTable dt = new System.Data.DataTable(); 
                    dt.Columns.Add("id"); dt.Columns.Add("name");
                    dt.Rows.Add("1", "Val1");
                    dt.Rows.Add("2", "Val2");
                %>
                <% foreach (System.Data.DataRow row in dt.Rows)
                  {%>
                <li id="<%= row["id"].ToString() %>">
                    <%= row["value"].ToString() %>
                </li>
                <%} %>
            </ul>
        </div>
    </form>
