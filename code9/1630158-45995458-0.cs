    public static void loadDDLModelli(ref DropDownList ddl, List<dynamic> objects)
    {
        Int16 cont = 0;
        ddl.Items.Clear();
        System.Web.UI.WebControls.ListItem li;
        String idModello = "";
        String nomeModello = "";
        String nomeBrand = "";
        String oggetto = "";
        List<System.Web.UI.WebControls.ListItem> items = new List<System.Web.UI.WebControls.ListItem>();
        foreach (var item in objects)
        {
            oggetto = item.ToString().Replace("{", "").Replace("}", "");
            idModello = oggetto.Split(',')[0].Split('=')[1].Trim();
            nomeModello = oggetto.Split(',')[1].Split('=')[1].Trim();
            nomeBrand = oggetto.Split(',')[2].Split('=')[1].Trim();
            li = new System.Web.UI.WebControls.ListItem(nomeBrand+" - "+nomeModello, idModello);
            li.Attributes["Group"] = nomeBrand;
            items.Add(li);
            cont++;
        };
        //ddl.DataSource = items;
        //ddl.DataBind();
        foreach(ListItem i in items)
           ddl.Items.Add(i);
        ddl.SelectedIndex = -1;
    }
