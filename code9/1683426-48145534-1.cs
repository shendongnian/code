    public void Createddl(string id)
    {
        DropDownList ddl = new DropDownList();
        ddl.ID = id;
        pnlSort.Controls.Add(ddl);
        Literal lt = new Literal();
        lt.Text = "<br />";
        pnlSort.Controls.Add(lt);
        pnlSort.Attributes.Add("style", "display:block");
    }
